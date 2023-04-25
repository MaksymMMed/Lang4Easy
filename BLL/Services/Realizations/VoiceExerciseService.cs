using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace BLL.Services.Realizations
{
    public class VoiceExerciseService : IVoiceExerciseService
    {
        private SpeechRecognitionEngine _speechRecognitionEngine;
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public VoiceExerciseService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public async Task AddVoiceExercise(VoiceExerciseRequest request)
        {
            var item = mapper.Map<VoiceExercise>(request);
            await unit.voiceExerciseRepository.Insert(item);

            var users = await unit.UserRepository.GetAll();

            var exercise = await unit.voiceExerciseRepository.FindByData(request.Name!, request.LessonId, request.TextToSay!, request.Answer!);
            foreach (var user in users)
            {
                CompleteStatus status = new();
                status.UserId = user.Id;
                status.ExerciseId = exercise.Id;
                status.Status = false;
                await unit.completeStatusRepository.Insert(status);
            }
        }

        public async Task DeleteVoiceExercise(int id)
        {
            await unit.voiceExerciseRepository.Delete(id);
        }

        public async Task<VoiceExerciseResponse> GetVoiceExerciseById(int id)
        {
            var item = await unit.voiceExerciseRepository.GetById(id);
            return mapper.Map<VoiceExerciseResponse>(item);
        }

        public async Task UpdateVoiceExercise(VoiceExerciseRequest request)
        {
            var item = mapper.Map<VoiceExercise>(request);
            await unit.voiceExerciseRepository.Update(item);
        }

        public async Task SayText(string textToSay)
        {

            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
            Prompt text = new Prompt(textToSay);
            synthesizer.SpeakAsync(text);
        }

        public void CheckVoice()
        {
            using (
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine
            (new System.Globalization.CultureInfo("en-US")))
            {

                // Create and load a dictation grammar.  
                recognizer.LoadGrammar(new DictationGrammar());

                // Add a handler for the speech recognized event.  
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognitionEngine_SpeechRecognized!);

                recognizer.SpeechRecognitionRejected +=
                    new EventHandler<SpeechRecognitionRejectedEventArgs>(SpeechRecognitionEngine_SpeechRecognitionRejected!);

                // Configure input to the speech recognizer.  
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.  
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

            }
            void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                Console.WriteLine($"Recognized: {e.Result.Text}");
            }

            void SpeechRecognitionEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
            {
                Console.WriteLine($"Rejected: {e.Result.Text}");
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
                Prompt text = new Prompt("I dont understand");
                synthesizer.SpeakAsync(text);
            }
        }

            

            public async Task<bool> CheckRecognizedText(CheckVoiceRequest checkVoice)
            {
                var exercise = await unit.voiceExerciseRepository.GetById(checkVoice.exerciseId);

                if (exercise.Answer == checkVoice.recognizedText!.Trim())
                {
                    var item = await unit.completeStatusRepository.GetComplete(checkVoice.userId, exercise.Id);
                    item.Status = true;
                    await unit.completeStatusRepository.Update(item);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

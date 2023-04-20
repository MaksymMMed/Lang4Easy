using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo.Interfaces;
using DAL.UnitOfWork;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace BLL.Services.Realizations
{
    public class VoiceExerciseService : IVoiceExerciseService
    {
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

        public Task CheckText(VoiceExerciseRequest request)
        {
            /*SpeechRecognizer recognizer = new SpeechRecognizer();
            Choices colors = new Choices(new string[] { "red", "blue", "green" });
            GrammarBuilder gb = new GrammarBuilder(colors);
            Grammar grammar = new Grammar(gb);
            recognizer.LoadGrammar(grammar);

            // Обробник події розпізнавання мовлення
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Початок розпізнавання мовлення
            recognizer.(RecognizeMode.Multiple);

            // Обробник події розпізнавання мовлення

            */
            return Task.CompletedTask;
              
        }

        public async Task<bool> CheckRecognizedText(CheckVoiceRequest checkVoice)
        {
            var exercise = await unit.voiceExerciseRepository.GetById(checkVoice.exerciseId);

            if (exercise.Answer == checkVoice.recognizedText.Trim())
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

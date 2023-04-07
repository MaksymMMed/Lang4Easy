using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo.Interfaces;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace BLL.Services.Realizations
{
    public class VoiceExerciseService : IVoiceExerciseService
    {
        private readonly IVoiceExerciseRepository repository;
        private readonly IMapper mapper;

        public VoiceExerciseService(IVoiceExerciseRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddVoiceExercise(VoiceExerciseRequest request)
        {
            var item = mapper.Map<VoiceExercise>(request);
            await repository.Insert(item);
        }

        public async Task DeleteVoiceExercise(int id)
        {
            await repository.Delete(id);
        }

        public async Task<VoiceExerciseResponse> GetVoiceExerciseById(int id)
        {
            var item = await repository.GetById(id);
            return mapper.Map<VoiceExerciseResponse>(item);
        }

        public async Task UpdateVoiceExercise(VoiceExerciseRequest request)
        {
            var item = mapper.Map<VoiceExercise>(request);
            await repository.Update(item);
        }

        public Task SayText(VoiceExerciseRequest request)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
            synthesizer.SpeakAsync(request.TextToSay);
            return Task.CompletedTask;
        }

        public Task CheckText(VoiceExerciseRequest request)
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();
            Choices colors = new Choices(new string[] { "red", "blue", "green" });
            GrammarBuilder gb = new GrammarBuilder(colors);
            Grammar grammar = new Grammar(gb);
            recognizer.LoadGrammar(grammar);

            // Обробник події розпізнавання мовлення
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Початок розпізнавання мовлення
            recognizer.(RecognizeMode.Multiple);

            // Обробник події розпізнавання мовлення
              
        }
        private static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized: " + e.Result.Text);
        }


    }
}

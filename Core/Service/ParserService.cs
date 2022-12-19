using Core.Entities;
using MediatR;
using ParserLib.Entities;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ParserService      
    {
        private ParserWorker parser;
        public ParserService(IMediator mediatR)
        {
            parser = new ParserWorker
            (
                new AniDubParser(mediatR),
                new AniDubSettings()
            );
        }

        public async Task FillDataBaseAniDub()
        {
            await parser.Start();
        }
    }
}  

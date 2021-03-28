using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.InstalledString;
using GuitarManager.DataAccess.CQRS.Queries.MyInstrument;
using GuitarManager.DataAccess.CQRS.Queries.Sound;
using GuitarManager.DataAccess.CQRS.Queries.String;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.InstalledString
{
    class CheckInstalledString
    {
        public static async Task<bool> CheckIfCorrect<T>(T request, IQueryExecutor queryExecutor)
            where T : IAddAndUpdateInstalledStringProperties
        {
            var queryNewInstalledString = new GetInstalledStringByPositionAndMyInstrumentQuery()
            {
                MyInstrumentID = request.MyInstrumentID,
                StringPosition = request.StringPosition
            };
            var gotNewInstalledString = await queryExecutor.Execute(queryNewInstalledString);

            var querySound = new GetSoundByIdQuery()
            {
                Id = request.SoundID
            };
            var gotSound = await queryExecutor.Execute(querySound);

            var queryMyInstrument = new GetMyInstrumentByIdQuery()
            {
                Id = request.MyInstrumentID
            };
            var gotMyInstrument = await queryExecutor.Execute(queryMyInstrument);

            var queryString = new GetStringByIdQuery()
            {
                Id = request.StringID
            };
            var gotString = await queryExecutor.Execute(queryString);

            if (gotNewInstalledString == null && gotSound != null && gotMyInstrument != null && gotString != null)
                return true;
            else
                return false;
        }
    }
}

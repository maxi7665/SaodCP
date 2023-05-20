using static SaodCP.Database.HostelContext;

namespace SaopCPTest
{
    [TestClass]
    public class HostelContextTest
    {
        [TestMethod]
        public void PeriodAddTest()
        {
            InitTestData();

            var lodger = Lodgers.First().Value;
            var room = Apartments.First().Value;

            string error = string.Empty;

            var startDate = DateOnly.FromDateTime(DateTime.Now);

            var started = StartAccomodation(
                lodger.PassportId,
                room.Number,
                startDate,
                ref error);

            Assert.IsTrue(started);
            Assert.AreEqual(Accommodations.Count, 1);

            // пытаемся повторно заселить того
            // же постояльца в то же место
            started = StartAccomodation(
                lodger.PassportId,
                room.Number,
                startDate,
                ref error);

            Assert.IsFalse(started);
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));

            // на дату позже
            started = StartAccomodation(
                lodger.PassportId,
                room.Number,
                startDate.AddDays(5),
                ref error);

            Assert.IsFalse(started);
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));

            // пытаемся выселить на день раньше чем заселили
            var ended = EndAccomodation(
                lodger.PassportId,
                room.Number,
                startDate.AddDays(-1),
                ref error);

            Assert.IsFalse(ended);
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));

            // выселяем успешно
            ended = EndAccomodation(
                lodger.PassportId,
                room.Number,
                startDate.AddDays(5),
                ref error);

            Assert.IsTrue(ended);
            Assert.IsTrue(string.IsNullOrWhiteSpace(error));

            // выселяем повторно (должна быть ошибка)
            ended = EndAccomodation(
                lodger.PassportId,
                room.Number,
                startDate.AddDays(5),
                ref error);

            Assert.IsFalse(ended);
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }
    }
}
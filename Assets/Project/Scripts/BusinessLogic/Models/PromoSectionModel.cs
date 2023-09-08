using PromoTest.Project.BusinessLogic.Interfaces.Models;

namespace PromoTest.Project.BusinessLogic.Models
{
    public class PromoSectionModel : IPromoSectionModel
    {
        public string SectionTitle { get; }

        public PromoSectionModel(string sectionTitle)
        {
            SectionTitle = sectionTitle;
        }
    }
}
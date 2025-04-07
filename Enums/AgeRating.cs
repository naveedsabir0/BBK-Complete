using Microsoft.OpenApi.Attributes;

namespace MovieDatabaseBlazorServerApp.Enums
{
    public enum AgeRating
    {
        U,
        PG,
        [DisplayAttribute("12A")]
        TwelveA,
        [DisplayAttribute("12")]
        Twelve,
        [DisplayAttribute("15")]
        Fifteen,
        [DisplayAttribute("18")]
        Eighteen,
        R18
    }


}

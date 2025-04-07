using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MovieDatabaseBlazorServerApp.Enums;

namespace MovieDatabaseBlazorServerApp.Components.Pages
{
    public class EditablePageBase : PageBase
    {
        [Parameter]
        public int Id { get; set; }

        [CascadingParameter]
        public EditContext CurrentEditContext { get; set; }

        protected ValidationMessageStore MessageStore { get; set; }

        public Mode Mode => Id == 0 ? Mode.Create : Mode.Edit;
    }
}

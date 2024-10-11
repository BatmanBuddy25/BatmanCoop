using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BatmanCoop.Client.Pages.LendPage.BuyerDialogPage
{
    public partial class BuyerApprovePage : ComponentBase
    {
        [CascadingParameter] public FluentDialog? Dialog { get; set; }
        [Parameter] public BuyerDetailsModel Content { get; set; } = default!;
    }
}

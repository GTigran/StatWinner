module StatWinner.Common.ControllerExtensions {

    export var kendoGridManagementExtensions =
    {
        kendoObservableArray: new kendo.data.ObservableArray([]),
        SelectAll: false,
        HasGridSelectedItems: function() {
            var arr = this.kendoObservableArray;
            var hasSelected = false;
            for (var i = 0; i < arr.length; ++i) {
                hasSelected = arr[i].IsSelected;
                if (hasSelected) {
                    break;
                }
            }
            return hasSelected;
        },
        RemoveSelectedItems: function() {
            var arr = this.kendoObservableArray;
            for (var i = 0; i < arr.length; ++i) {
                if (arr[i].IsSelected) {
                    arr.splice(i, 1);
                    --i;
                }
            }
        }
    }
}
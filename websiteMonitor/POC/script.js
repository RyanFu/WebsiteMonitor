$(document).ready(function(){
            var hidden = false;

    $("#actionButton").on('click',function(){
        var myDivToMonitor = $("#monitorMe");
        if(!hidden){
        
        myDivToMonitor.removeClass("removeMe");
        myDivToMonitor.hide();
            hidden = true;
        } else{
            myDivToMonitor.addClass("removeMe");
            myDivToMonitor.show();
                        hidden = false;

        }
        
    })
})
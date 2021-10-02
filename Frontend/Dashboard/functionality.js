function selectDashboard(index){

    var elements = document.getElementById("dashboard_view_container").getElementsByTagName("div");
    
    for (var i=0;i<elements.length;i++){
        elements[i].style.display="none";
    }

    elements[index].style.display = "block";

}
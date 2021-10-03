function selectDashboard(index){

    var elements = document.getElementById("dashboard_view_container").getElementsByClassName("dashboard_view");
    
    for (var i=0;i<elements.length;i++){
        elements[i].style.display="none";
    }

    elements[index].style.display = "block";
}

function buildTeamsDashboard(){
    var data = requestTeams();

    
    document.getElementById("team_menu").innerHTML = "";
    //for(var j=0;j<=10;j++){
        for(var i=0;i<data["teams"].length;i++){
            document.getElementById("team_menu").appendChild(buildTeamsMenuItem(data["teams"][i]));
            document.getElementById("team_menu").append(buildTeamMenuItemContent(data["teams"][i]));
        }
    //}

}

function buildTeamsMenuItem(object){
    var team_container = document.createElement("div");
    var team_item = document.createElement("span");
    var team_icon = document.createElement("i");
    team_icon.setAttribute("class","glyphicon glyphicon-circle-arrow-right");
    team_icon.setAttribute("id", "TII"+object.id);
    team_item.appendChild(document.createTextNode(object.name));
    team_container.setAttribute("class", "team_menu_item");
    team_container.appendChild(team_icon);
    team_container.appendChild(team_item);
    buildTeamMenuItemEvent(team_container, object);
    return team_container;
}

function buildTeamMenuItemEvent(container, object){
    container.onclick = function(){
        var content = document.getElementById(object.id);
        var item_icon = document.getElementById("TII"+object.id);

        if(content.style.display === "none"){
            content.style.display = "block";
            item_icon.classList.remove("glyphicon-circle-arrow-right");
            item_icon.classList.add("glyphicon-circle-arrow-down");
            //container.style.backgroundColor = "rgb(56, 56, 56)";
        }else{
            content.style.display = "none";
            item_icon.classList.add("glyphicon-circle-arrow-right");
            item_icon.classList.remove("glyphicon-circle-arrow-down");
            //container.style.backgroundColor = "rgb(0, 0, 0)";
        }
    }
}

function buildTeamMenuItemContent(object){
    var team_content = document.createElement("div");
    team_content.setAttribute("class", "team_menu_item_content");
    team_content.setAttribute("id", object.id);
    team_content.style.display="none";
    //window.alert(object["groups"][i]);
    for(var i=0;i<object.groups.length;i++){
        team_content.appendChild(buildTeamItem(object.groups[i]));
       
    }
    return team_content;
}



function buildTeamItem(object){
    var content_container = document.createElement("div");
    var  content_item = document.createElement("p");
    content_item.appendChild(document.createTextNode(object.name));
    content_container.appendChild(content_item);
    return content_container;
}

function buildTeamItemEvent(container, object){

}

function requestTeams(){
    var url = "file:///C:\Users\tase2\Desktop\Bachelor\BachelorDegree\Frontend\Dashboard\data.json";
    /*var request = new XMLHttpRequest();
    request.open("GET", url, false);
    request.send(null);
    request.onreadystatechange == function(){
        if(request.readyState === 4){
            
        }
    }*/

    let data = JSON.parse('{"teams":[{"id":"T1", "name":"Team 1","groups":[{"teamId":"T1", "name":"Group 1","private":1},{"teamId":"T1", "name":"Group 2","private":1},{"teamId":"T1", "name":"Group 3","private":1}]},{"id":"T2","name":"Team 2","groups":[{"teamId":"T2", "name":"Group 1","private":1},{"teamId":"T2","name":"Group 2","private":1},{"teamId":"T2","name":"Group 3","private":1}]},{"id":"T3","name":"Team 3","groups":[{"teamId":"T3","name":"Group 1","private":1},{"teamId":"T3","name":"Group 2","private":1},{"teamId":"T3","name":"Group 3","private":1}]},{"id":"T4","name":"Team 4","groups":[{"teamId":"T4","name":"Group 1","private":1},{"teamId":"T4","name":"Group 2","private":1},{"teamId":"T4","name":"Group Special","private":1}]}]}');
    return data;
}
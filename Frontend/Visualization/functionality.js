
function drawGraph(data){
    var container = document.getElementById("visualization_container");
    
    var receivers = data["uElements"];
    var givers = data["tElements"];
    var gp = [], rp = []
    var container_givers = document.createElement("div");
    container_givers.style.width = "50%";
    container_givers.style.display = "block";
    container_givers.style.background = "transparent";

    /*for(var i=0;i<givers.length;i++){
        var node = createNode("G", i+1);
        node.setAttribute("id", "G#"+givers[i]["id"]);
        container_givers.appendChild(node);
    }*/


    var container_receivers = document.createElement("div");
    container_receivers.style.width = "50%";
    container_receivers.style.display = "block";
    container_receivers.style.background = "transparent";

    /*for(var i=0;i<receivers.length;i++){
        var node = createNode("R", i+1);
        node.setAttribute("id", "R#"+receivers[i]["id"]);
        container_receivers.appendChild(node);
    }*/

    var n = 20;
    /*createNodeOnSVG("G", 100, 100);
    createNodeOnSVG("R", 550, 100);
    createEdge(130, 100, 520, 100);*/
    for(var i=0;i<n;i++){
        /*var node1 = createNodeOnSVG("G", i+1);
        var node2 = createNode("R", i+1);
        container_givers.appendChild(node1);
        container_receivers.appendChild(node2);
        givers[i] = node1;
        receivers[i] = node2;*/
        createNodeOnSVG("G", 100, (i+1)*100, "G#");
        gp[i] = {x:100, y:(i+1)*100}
        createNodeOnSVG("R", 550, (i+1)*100, "R#");
        rp[i] = {x:550, y:(i+1)*100}
        //createEdge(130, (i+1)*100, 520, (i+1)*100);
        //createEdge(node1.getBoundingClientRect(), node2.getBoundingClientRect());
    }
    /*container.appendChild(container_givers);
    container.appendChild(container_receivers);*/
    for(var i=0;i<n;i++){
        for(var j=0;j<n;j++){
            createEdge(gp[i].x + 30, gp[i].y, rp[j].x - 30, rp[j].y);
        }
    }

}

function createNode(type, index){


    var element = document.createElement("div");
    element.style.width = "50px";
    element.style.height = "50px";
    element.style.border = "1px solid black";
    element.style.borderRadius = "100%";
    element.style.cursor = "pointer";
    element.style.transitionDuration = "0.3s";
    element.addEventListener("mouseover", function(event) {
        element.style.backgroundColor = "black";
        element.style.border = "1px solid green";
    })
    element.addEventListener("click", function(event){
        requestPersonInfo(element.id);
    })
    if(type === "G"){
        element.style.backgroundColor = "green";
        element.style.marginTop = "70px";
        element.style.marginLeft = "15%";
        element.style.marginRight = "60%";
        element.addEventListener("mouseout", function(event) {
            element.style.backgroundColor = "green";
            element.style.border = "1px solid black";
        })
        
    }else{
        element.style.backgroundColor = "red";
        element.style.marginTop = "70px";
        element.style.marginRight = "15%";
        element.style.marginLeft = "60%";
        element.addEventListener("mouseout", function(event) {
            element.style.backgroundColor = "red";
            element.style.border = "1px solid black";
        })
    }

    

    return element;
}

function createNodeOnSVG(type, cx, cy, id){
    var container = document.getElementById("edge_container");
    container.style.height = (container.getBBox().height + 100) + 'px';
    var element = document.createElementNS('http://www.w3.org/2000/svg',"circle");
    element.setAttribute('id', id);
    element.setAttribute('cx', cx);
    element.setAttribute('cy', cy);
    element.setAttribute('r', 30);
    element.setAttribute('stroke', 'black');
    element.style.cursor = "pointer";
    element.style.transitionDuration = "0.3s";
    element.addEventListener("mouseover", function(event) {
        element.setAttribute('fill', 'black');
    })
    element.addEventListener("click", function(event){
        requestPersonInfo(element.id);
    })
    if(type === "R"){
        element.addEventListener("mouseout", function(event) {
            element.setAttribute('fill', 'red');
        })
        element.setAttribute('fill', 'red');
    }else{
        element.addEventListener("mouseout", function(event) {
            element.setAttribute('fill', 'green');
        })
        element.setAttribute('fill', 'green');
    }

    container.append(element);
}

function createEdge(x1, y1, x2, y2){
    var container = document.getElementById("edge_container");
    var element = document.createElementNS('http://www.w3.org/2000/svg',"line");
    element.setAttribute('id','line2');
    element.setAttribute('x1', x1);
    element.setAttribute('y1', y1);
    element.setAttribute('x2', x2);
    element.setAttribute('y2', y2);
    element.setAttribute('stroke', 'black');
    container.append(element);
}

function displayPersonInfo(data, subjectType){

    if(subjectType === 'G'){
        document.getElementById("subject_type_info_container").innerHTML = "Donnor informations";
    }else{
        document.getElementById("subject_type_info_container").innerHTML = "Patient informations";
    }

    var elements = document.getElementById("subject_information_display").getElementsByTagName("td");
    for(var i=1;i<elements.length;i+=2)
    {
        elements[i].getElementsByTagName("span")[0].innerHtml = "";
    }

    elements[1].getElementsByTagName("span")[0].innerHTML = data.firstName + " " + data.lastName;
    elements[3].getElementsByTagName("span")[0].innerHTML = data.country + ", " + data.city;
    elements[5].getElementsByTagName("span")[0].innerHTML = data.email;
    elements[7].getElementsByTagName("span")[0].innerHTML = data.phoneNumber;

    elements = document.getElementById("subject_medical_display").getElementsByTagName("td");
    for(var i=1;i<elements.length;i+=2)
    {
        elements[i].getElementsByTagName("span")[0].innerHtml = "";
    }

    elements[1].getElementsByTagName("span")[0].innerHTML = data.age;
    elements[3].getElementsByTagName("span")[0].innerHTML = SEX[data.sex].toLowerCase();
    elements[5].getElementsByTagName("span")[0].innerHTML = RACE[data.race].toLowerCase();
    elements[7].getElementsByTagName("span")[0].innerHTML = BLOOD_TYPE[data.bloodType];
    elements[9].getElementsByTagName("span")[0].innerHTML = PRIMARY_DIAGNOSIS[data.primaryDiagnosis];
}

function requestPersonInfo(id){
    var url = "https://localhost:5001/";
    var pID = id.split("#");
    if(pID[0] === "G"){
        url = url + "giver/info";
    }else{
        url = url + "receiver/info";
    }
    var request = new XMLHttpRequest();
    request.open("POST", url,false);
    request.setRequestHeader('Content-Type', 'application/json');
    request.onreadystatechange = function(){
        if(request.readyState == 4 && request.status == 200){
            //displayPersonInfo(JSON.parse(request.response));
            displayPersonInfo(JSON.parse(request.response), pID[0]);
        }
    }
    request.send(JSON.stringify({
        id: parseInt(pID[1])
    }));
    
}


function requestCompatibilities(){
    var request = new XMLHttpRequest();
    request.open("POST", "https://localhost:5001/matching/result",false);
    request.setRequestHeader('Content-Type', 'application/json');
    request.onreadystatechange = function(){
        if(request.readyState == 4 && request.status == 200){
            drawGraph(JSON.parse(request.response));
        }
    }
    request.send(JSON.stringify({
        algorithmVariant: 0
    }));
}

function requestPerfectMatching(){
    var request = new XMLHttpRequest();
    request.open("POST", "https://localhost:5001/matching/result",false);
    request.setRequestHeader('Content-Type', 'application/json');
    request.onreadystatechange = function(){
        if(request.readyState == 4 && request.status == 200){
            drawGraph(JSON.parse(request.response));
        }
    }
    request.send(JSON.stringify({
        algorithmVariant: 0
    }));
}

function requestMaximalMatching(){
    var request = new XMLHttpRequest();
    request.open("POST", "https://localhost:5001/matching/result",false);
    request.setRequestHeader('Content-Type', 'application/json');
    request.onreadystatechange = function(){
        if(request.readyState == 4 && request.status == 200){
            drawGraph(JSON.parse(request.response));
        }
    }
    request.send(JSON.stringify({
        algorithmVariant: 0
    }));
}


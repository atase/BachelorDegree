function drawGraph(data){
    console.log(data);
    var container = document.getElementById("visualization_container");

    var receivers = data["uElements"];
    var givers = data["tElements"];

    var container_givers = document.createElement("div");
    container_givers.style.width = "50%";
    container_givers.style.display = "block";

    for(var i=0;i<givers.length;i++){
        var node = createNode("G", i+1);
        node.setAttribute("id", "G#"+givers[i]["id"]);
        container_givers.appendChild(node);
    }


    var container_receivers = document.createElement("div");
    container_receivers.style.width = "50%";
    container_receivers.style.display = "block";

    for(var i=0;i<receivers.length;i++){
        var node = createNode("R", i+1);
        node.setAttribute("id", "R#"+receivers[i]["id"]);
        container_receivers.appendChild(node);
    }
    

    container.appendChild(container_givers);
    container.appendChild(container_receivers);

    /*for(var i=0;i<receivers.length;i++){
        var node = createNode("R", i+1);
        
        container_row.appendChild(node);
        container.appendChild(container_row);
    }*/

    /*for(var i=0;i<n;i++){
        var node1 = createNode("G", i+1);
        var node2 = createNode("R", i+1);

        var container_row = document.createElement("div");
        container_row.style.width = "100%";
        container_row.style.display = "inline-block";
        container_row.appendChild(node1);
        container_row.appendChild(node2);
        
        givers[i] = node1;
        receivers[i] = node2;
        container.appendChild(container_row);

        var edge = createEdge(node1.getBoundingClientRect(), node2.getBoundingClientRect());
        container.appendChild(edge);
    }

    /*for(var i=0;i<n;i++){
        for(var j=0;j<n;j++){
            if(i!=j){
                var edge = createEdge(givers[i].getBoundingClientRect(), receivers[j].getBoundingClientRect());
                container.appendChild(edge);
            }
            
        }
    }*/

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

function createEdge(position1, position2){
    var x1 = position1.left + position1.width;
    var y1 = position1.top - (position1.height/2);

    var x2 = position2.left;
    var y2 = position2.top - (position1.height/2);

    var length = Math.sqrt(((x2-x1) * (x2-x1)) + ((y2-y1) * (y2-y1)));

    var angle = Math.atan2((y1-y2),(x1-x2))*(180/Math.PI);
    //var cx = ((x1 + x2) / 2) - (length / 2) - 178;
    //var cy = -((y1+y2)/2) + 70;
    var cy = -(25 + 4.7);

    var element = document.createElement("div");
    element.style.height = "2px";
    element.style.width = length + "px";
    element.style.position = "relative";
    element.style.left = 21.40 + "%";
    element.style.top = cy + "px";
    //element.style.top = cy + "px";
    //element.style.left = cx + "px";
    element.style.backgroundColor = "black";
    element.style.mozTransform    = 'rotate('+angle+'deg)'; 
    element.style.msTransform     = 'rotate('+angle+'deg)'; 
    element.style.oTransform      = 'rotate('+angle+'deg)'; 
    element.style.transform       = 'rotate('+angle+'deg)'; 

    return element;
}




function displayPersonInfo(data){
    console.log(data);
    var container = document.getElementById("person_information_container");
    container.innerHTML = "";
    var p = document.createElement("p");
    p.innerText = data;
    container.appendChild(p);
}

function requestMatch(){
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
            displayPersonInfo(request.response);
        }
    }
    request.send(JSON.stringify({
        id: parseInt(pID[1])
    }));
    
}


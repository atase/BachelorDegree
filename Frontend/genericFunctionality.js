function writeStatistics(data){
    var container = document.getElementById("generic_informations");
    //var paragraphs = container.getElementsByTagName("p");
    container.innerHTML = '';

    var p1 = document.createElement("p");
    p1.innerText = "Number of subjects: " + data.numberOfSubjects;
    var p2 = document.createElement("p");
    p2.innerText = "Number of givers: " + data.numberOfGivers;
    var p3 = document.createElement("p");
    p3.innerText = "Number of receivers: " + data.numberOfReceivers;

    container.appendChild(p1);
    container.appendChild(p2);
    container.appendChild(p3);

}   


function reqGetStatistics(){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.compatibilityStatistics ,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            writeStatistics(JSON.parse(req.response));
        }
    }
    req.send();
}


function displaySuccessContainer(message){
    document.getElementById("message_container_background_id").style.display="block";
    document.getElementById("confirmation_container_id").style.display="block";
    document.getElementById("confirmation_container_message_id").innerText = message;
}

function displayErrorContainer(message){
    document.getElementById("message_container_background_id").style.display="block";
    document.getElementById("error_container_id").style.display="block";
    document.getElementById("error_container_message_id").innerText = message; 
}

function reqGenerateScores(){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.compatibilityGenerateScores ,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            reinitialize_container_on_generate_scores();
            displaySuccessContainer("Compatibility scores have been generated.");
        }else{
            displayErrorContainer("Failed to generate new scores, please try again.");
        }
    }
    req.send();
}
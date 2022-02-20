function writeStatistics(data){
    var container = document.getElementById("generic_informations");
    var paragraphs = container.getElementsByTagName("p");
    console.log(data);
    paragraphs[0].innerText = paragraphs[0].innerText + data.numberOfSubjects;
    paragraphs[1].innerText = paragraphs[1].innerText + data.numberOfGivers;
    paragraphs[2].innerText = paragraphs[2].innerText + data.numberOfReceivers;

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
            displaySuccessContainer("Compatibility scores have been generated.");
        }else{
            displayErrorContainer("Failed to generate new scores, please try again.");
        }
    }
    req.send();
}
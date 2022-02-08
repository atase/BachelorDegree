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

function reqGenerateScores(){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.compatibilityGenerateScores ,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            console.log(req.response);
        }
    }
    req.send();
}
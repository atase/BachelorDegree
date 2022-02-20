function load_data(){
    draw_intro_graph();
}

function display_main_container(){
    document.getElementById("top_container_id").style.display="none";
    document.getElementById("main_container").style.display="block";
    select_subject_tab('R')
}

function draw_intro_graph(){
    var c1 = document.getElementById("tr_column1");

    var gd = [];
    var gcoords = [];


    var rd = [];
    var rcoords = [];

    var elRect;

    for(var i=0;i<4;i++)
    {
        var el = document.createElement("div");
        el.style.width = "50px";
        el.style.height = "50px";
        el.style.borderRadius = "50%";
        el.style.backgroundColor = "white";
        el.style.marginTop = "70px";
        el.style.marginLeft = "47%";
        c1.appendChild(el);
        gd[i] = false;
    }

    console.log(gcoords);
    var c2 = document.getElementById("tr_column2");

    for(var i=0;i<4;i++)
    {
        var el = document.createElement("div");
        el.style.width = "50px";
        el.style.height = "50px";
        el.style.borderRadius = "50%";
        el.style.backgroundColor = "black";
        el.style.marginLeft = "47%";
        el.style.marginTop = "70px";
        c2.appendChild(el);
        rd[i] = false;
    }

}

function add_to_array(obj, arr){
    console.log("obj" + obj);
    if(arr.length == 0){
        arr[arr.length] = obj;
        return true;
    }

    for(var i=0;i<arr.length;i++){
        if(arr[i]['id'] == obj['id']){
            return false;
        }
    }

    arr[arr.length] = obj;
    return true;
}

function index_of_object(obj, arr){
    for(var i=0;i<arr.length;i++){
            if(arr[i]['id'] == obj['id']){
                return i;
            }
        }
}

function add_subject_score_to_array(subject, value, arr){
    if(arr.length == 0){
        arr[0] = {id: subject.id, scores: []};
        arr[0].scores.push(value);
        return;
    }

    for(var i=0;i<arr.length;i++){
        if(arr[i].id == subject.id){
            arr[i].scores.push(value);
            return;
        }
    }

    arr[arr.length] = {id: subject.id, scores: []}
    arr[arr.length-1].scores.push(value);

}

function compare_subjects(x, y){
    if(x.id < y.id){
        return -1;
    }
    if(x.id > y.id){
        return 1;
    }
    return 0;
}


function draw_compatibilities(data){
    var container = document.getElementById("cedge_container");
    container.innerHTML = "";
    var receivers = [];
    var givers = [];
    var gp = [], rp = []



    var scores = [];
    var givers_scores = [];
    var receivers_scores = [];


    var rs = 0;
    for(var i=0;i<data['compatibilityScores'].length;i++){
        add_to_array(data['compatibilityScores'][i]['first']['first'], givers);
        add_to_array(data['compatibilityScores'][i]['first']['second'], receivers);
        add_subject_score_to_array( data['compatibilityScores'][i]['first']['first'],
                                    data['compatibilityScores'][i]['second'],
                                    givers_scores);

        add_subject_score_to_array( data['compatibilityScores'][i]['first']['second'],
                                    data['compatibilityScores'][i]['second'],
                                    receivers_scores)
        scores[rs++] = {gid:data['compatibilityScores'][i]['first']['first']['id'], 
                            gidx: index_of_object(data['compatibilityScores'][i]['first']['first'], givers), 
                            rid:data['compatibilityScores'][i]['first']['second']['id'], 
                            ridx: index_of_object(data['compatibilityScores'][i]['first']['second'], receivers), 
                            score:data['compatibilityScores'][i]['second']}
        
    }
    console.log("Givers");
    givers.forEach(e => console.log(e));
    console.log("Receivers" + receivers.length);
    receivers.forEach(e => console.log(e));
    console.log("Giver scores");
    givers_scores.forEach(e => e.scores.forEach( s => console.log(e.id + " -> " + s)))
    console.log("Receivers scores");
    receivers_scores.forEach(e => e.scores.forEach( s => console.log(e.id + " -> " + s)))

    var xgc = 340;
    var xrc = 840;
    var ycm = 100;

    for(var i=0;i<givers.length;i++){
        gp[i] = {x:xgc, y:(i+1)*ycm}
        createNodeOnSVG("G", xgc, (i+1)*ycm, "G#"+givers[i]['id'], container);

        createInfoContainerOnSVG("G", givers[i], givers_scores[i].scores, gp[i], container);
    }

    for(var i=0;i<receivers.length;i++){
        rp[i] = {x:xrc, y:(i+1)*ycm}
        createNodeOnSVG("R", xrc, (i+1)*ycm, "R#"+receivers[i]['id'], container);

        createInfoContainerOnSVG("R", receivers[i], receivers_scores[i].scores, rp[i], container);

    }
    console.log("Scores length" + scores.length);

    for(var i=0;i<scores.length;i++){
        if(scores[i].score != 0){
            createEdge(gp[scores[i]['gidx']].x + 30, gp[scores[i]['gidx']].y, rp[scores[i]['ridx']].x - 30, rp[scores[i]['ridx']].y, container);
        }
    }

}

function createInfoContainerOnSVG(type, subject, scores, cords, container){
    var text = "[" + subject.firstName + " " + subject.lastName + ", Blood type: " + subject.bloodType + "]";
    console.log(scores);
    var scoresText = "[ "
    
    for(var i=0;i<scores.length;i++){
        if(scores[i] != 0){
            scoresText = scoresText + scores[i] + ", ";
        }
        
    }

    if(scoresText.length > 2){
        scoresText = scoresText.slice(0, -2) + " ]";
    }else{
        scoresText = scoresText.slice(0, -1) + " ]";
    }


    var first = document.createElementNS('http://www.w3.org/2000/svg',"text");
    var second = document.createElementNS('http://www.w3.org/2000/svg',"text");


    if(type == 'G'){
        first.setAttributeNS(null, 'x', cords.x - 300);
        second.setAttributeNS(null, 'x', cords.x - 300);
    }
    else{
        first.setAttributeNS(null, 'x', cords.x + 50);
        second.setAttributeNS(null, 'x', cords.x + 50);
    }
    first.setAttributeNS(null, 'y', cords.y-15);
    second.setAttributeNS(null, 'y', cords.y+15);
    first.setAttributeNS(null, 'font-size', '15px');
    second.setAttributeNS(null, 'font-size', '15px');
    first.setAttributeNS(null, 'color', 'black');
    second.setAttributeNS(null, 'color', 'black');

    var node1 = document.createTextNode(text);
    var node2 =  document.createTextNode(scoresText);
    first.appendChild(node1);
    second.appendChild(node2);
    container.appendChild(first);
    container.appendChild(second);

}

function draw_optimal_assigment(data){

    var container = document.getElementById("oedge_container");
    container.innerHTML = "";
    var overallScore = data['MatchingValue'];
    var matching = data['optimalAssigment'];
    var receivers = [];
    var givers = [];
    var gp = [], rp = []

    var scores = [];

    var ri = 0;
    var rj = 0;
    var rs = 0;
    var givers_scores = [];
    var receivers_scores = [];

    for(var i=0;i<matching.length;i++){
        if(matching[i]['first']['first'] != null){
            if(add_to_array(matching[i]['first']['first'], givers)){
                ri++;
            }
            add_subject_score_to_array( givers[ri-1],
                                        matching[i]['second'],
                                        givers_scores);
        }

        if(matching[i]['first']['second'] != null){
            if(add_to_array(matching[i]['first']['second'], receivers)){
                rj++;
            }
            add_subject_score_to_array( receivers[rj-1],
                                        matching[i]['second'],
                                        receivers_scores)
        }
    }

    receivers.sort(compare_subjects);

    for(var i=0;i<matching.length;i++){
        if(matching[i]['first']['first'] != null && matching[i]['first']['second'] != null)
        {
            scores[rs++] =  {gid:matching[i]['first']['first']['id'], 
                            gidx: index_of_object(matching[i]['first']['first'], givers), 
                            id:matching[i]['first']['second']['id'], 
                            ridx: index_of_object(matching[i]['first']['second'], receivers), 
                            score:matching[i]['second']}
        }
    }


    var xgc = 340;
    var xrc = 840;
    var ycm = 100;
    
    receivers_scores.sort(compare_subjects);

    receivers.forEach(e => console.log("REC: " + e.id));
    scores.forEach(e => console.log("SC:" + e.gid + " " + e.id + " " + e.score));


    for(var i=0;i<givers.length;i++){
        gp[i] = {x:xgc, y:(i+1)*ycm}
        createNodeOnSVG("G", xgc, (i+1)*ycm, "G#"+givers[i]['id'], container);
        
        createInfoContainerOnSVG("G", givers[i], givers_scores[i] != null ? givers_scores[i].scores : [0], gp[i], container);
    }

    for(var i=0;i<receivers.length;i++){
        rp[i] = {x:xrc, y:(i+1)*ycm}
        createNodeOnSVG("R", xrc, (i+1)*ycm, "R#"+receivers[i]['id'], container);
        createInfoContainerOnSVG("R", receivers[i], receivers_scores[i] != null ? receivers_scores[i].scores : [0], rp[i], container);

    }
    console.log("Scores length" + scores.length);

    for(var i=0;i<scores.length;i++){
        if(scores[i].score != 0){
            createEdge(gp[scores[i]['gidx']].x + 30, gp[scores[i]['gidx']].y, rp[scores[i]['ridx']].x - 30, rp[scores[i]['ridx']].y, container);
        }
    }

}

function get_ridx_by_id(id, scores){

    for(var i=0;i<scores.length;i++){
        if(scores[i].id == id){
            return scores[i]['ridx'];
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
        element.style.backgroundColor = "#ECDBBA";
        element.style.marginTop = "70px";
        element.style.marginLeft = "15%";
        element.style.marginRight = "60%";
        element.addEventListener("mouseout", function(event) {
            element.style.backgroundColor = "#ECDBBA";
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

function createNodeOnSVG(type, cx, cy, id, container){
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
        request_subject_info(element.id);
    })
    if(type === "R"){
        element.addEventListener("mouseout", function(event) {
            element.setAttribute('fill', '#C84B31');
        })
        element.setAttribute('fill', '#C84B31');
    }else{
        element.addEventListener("mouseout", function(event) {
            element.setAttribute('fill', '#ECDBBA');
        })
        element.setAttribute('fill', '#ECDBBA');
    }

    container.appendChild(element);
}

function createEdge(x1, y1, x2, y2, container){
    var element = document.createElementNS('http://www.w3.org/2000/svg',"line");
    element.setAttribute('id','line2');
    element.setAttribute('x1', x1);
    element.setAttribute('y1', y1);
    element.setAttribute('x2', x2);
    element.setAttribute('y2', y2);
    element.setAttribute('stroke', 'black');
    container.appendChild(element);
}

function display_subject_info(data, subjectType){

    document.getElementById("background_container_id").style.display = "block";

    if(subjectType === 'G'){
        document.getElementById('trprimary_diagnosys_display').style.visibility = 'hidden';
        document.getElementById("subject_type_info_container").innerHTML = "Donnor informations";
    }else{
        document.getElementById('trprimary_diagnosys_display').style.visibility = 'visible;';
        document.getElementById("subject_type_info_container").innerHTML = "Patient informations";
    }

    document.getElementById('name_display').innerHTML = data['firstName'] + ' ' + data['lastName'];
    document.getElementById('country_display').innerHTML = data['country'] + ', ' + data['city'];
    document.getElementById('age_display').innerHTML = data['age'];
    document.getElementById('sex_display').innerHTML = data['sex'];

    document.getElementById('email_display').innerHTML = data['email'] != null ? data['email'] : 'Email not specified.';
    document.getElementById('phone_display').innerHTML = data['phoneNumber'] != null ? data['phoneNumber'] : 'Phone number not specified.';

    document.getElementById('race_display').innerHTML = data['race'] != null ? data['race'] : 'Race not specified.';
    document.getElementById('blood_display').innerHTML = data['bloodType'] != null ? data['bloodType'] : 'BloodType not specified.';

    document.getElementById('primary_diagnosys_display').innerHTML = data['primaryDiagnosis'] != null ? data['primaryDiagnosis'] : 'Primary diagnosis not specified.';
}

function request_subject_info(id){
    
    var pID = id.split("#");
    if(pID[0] === "G"){
        reqGiverInfo(pID[1])
    }else{
        reqReceiverInfo(pID[1])
    }
}


function reqReceiverInfo(id){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.receiverInfo + "?id=" + id,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            console.log(req.response);
            display_subject_info(JSON.parse(req.response), "R");
        }
    }
    req.send();
}


function reqGiverInfo(id){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.giverInfo + "?id=" + id,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            console.log(req.response);
            display_subject_info(JSON.parse(req.response), "G")
        }
    }
    req.send();
}


function reqCompatibilityScores(){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.compatiblityScores ,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            draw_compatibilities(JSON.parse(req.response));
        }
    }
    req.send();
}


function reqMatching(){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.matchingCompute,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            console.log(req.response);
            draw_optimal_assigment(JSON.parse(req.response));
        }
    }
    req.send();
}

/*MESSAGE CONTAINER */



function close_message_container(){
    document.getElementById("error_container_id").style.display="none";
    document.getElementById("confirmation_container_id").style.display="none";
    document.getElementById("message_container_background_id").style.display="none";

}
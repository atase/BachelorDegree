function display_filter_tab(){
    document.getElementById("background_efect_container_id").style.display = "block";
    document.getElementById("sample_data_filters_container_left_id").style.display = "block";


    if(document.getElementById("sd_pd_id").style.display == 'none'){
        document.getElementsByName("filter_pd")[0].style.display='none';
    }else{
        document.getElementsByName("filter_pd")[0].style.display='block';
    }
}

function hide_filter_tab(){
    document.getElementById("background_efect_container_id").style.display = "none";
    document.getElementById("sample_data_filters_container_left_id").style.display = "none";
}

function add_sdo_selection_effect(elem){
    var elements = document.getElementsByClassName("sd_func_btn");

    for(var i=0;i<elements.length;i++){
        elements[i].style.backgroundColor = "rgb(0, 91, 196)";
        elements[i].style.color = "rgb(0, 218, 73)";
    }

    elem.style.backgroundColor = "white";
    elem.style.color = "rgb(0, 119, 255)";

}

function select_subject_tab(subject){
    if(subject == 'G'){
        add_sdo_selection_effect(document.getElementById("givers_selection_id"));
        reqAllGivers();
    }else{
        add_sdo_selection_effect(document.getElementById("receivers_selection_id"));
        reqAllReceivers();
    }
}

function reinitialize_sample_data_table(){
    var rows = document.getElementById("sample_data_table_id").rows;
    var header = rows[0];
    document.getElementById("sample_data_table_id").innerHTML = header.innerHTML;
}

/*
    CONFIRMATION _CONTAINER
 */

function close_operations_confirmations_container(){
    document.getElementById("background_effect_operations_confirmations_id").style.display="none";
}

function display_operations_confirmations_container(op, subject_id, subject_type){

    document.getElementById("background_effect_operations_confirmations_id").style.display="block";
    if(op == "DELETE_SUBJECT"){
        document.getElementsByClassName("operations_confirmations_container_actions")[0].id = subject_id + "#" + subject_type + "#D";
        document.getElementById("operations_confirmations_message_info_id").innerText = "The subject will be deleted.";
    }else if(op == "UPDATE_SUBJECT"){
        document.getElementsByClassName("operations_confirmations_container_actions")[0].id = subject_id + "#" + subject_type + "#U";
        document.getElementById("operations_confirmations_message_info_id").innerText = "The subject will be updated.";
    }
}


/*** CONFIRMATION VARIABLE */
function operations_confirmations_positive(elem){
    var subject_id = elem.parentNode.id.split("#")[0];
    var subject_type = elem.parentNode.id.split("#")[1];
    var op_type = elem.parentNode.id.split("#")[2];

    if(op_type == "D"){ 
        if(subject_type == "G"){
            reqGiverDelete(subject_id);
        }else{
            reqReceiverDelete(subject_id);
        }
    }else{
        if(subject_type == "G"){
            var new_values = get_giver_data_input_values();
            reqGiverUpdate(subject_id, new_values);
        }else{
            var new_values = get_receiver_data_input_values();
            reqReceiverUpdate(subject_id, new_values);
        }
    }

    close_operations_confirmations_container();
}

function operations_confirmations_negative(elem){
    close_operations_confirmations_container();
}


/*
    ### UPDATE SUBJECT OPERATIONS

 */

function close_sample_data_options(){
    document.getElementById("background_effect_sd_operations_id").style.display="none";
    
}

function get_giver_data_input_values(){
    var i_fn = document.getElementsByName("g_firstName")[1];
    var i_ln = document.getElementsByName("g_lastName")[1];
    var i_age = document.getElementsByName("g_age")[1];

    var i_country = document.getElementsByName("g_country")[1];
    var i_city = document.getElementsByName("g_city")[1];

    var i_email = document.getElementsByName("g_email")[1];
    var i_phoneNumber = document.getElementsByName("g_phoneNumber")[1];
        

    var i_bt = document.getElementById("g_bloodType_clone");
    var i_r = document.getElementById("g_race_clone");
    var i_sex = document.getElementById("g_sex_clone");
    var giver = {
        FirstName: i_fn.value,
        LastName: i_ln.value,
        Country: i_country.value,
        City: i_city.value,
        Age: i_age.value,
        Email: i_email.value,
        PhoneNumber: i_phoneNumber.value,
        Sex: i_sex.value,
        Race: i_r.value,
        BloodType: i_bt.value,
    }

    return giver;
}

function get_receiver_data_input_values(){

    var i_fn = document.getElementsByName("r_firstName")[1];
    var i_ln = document.getElementsByName("r_lastName")[1];
    var i_age = document.getElementsByName("r_age")[1];

    var i_country = document.getElementsByName("r_country")[1];
    var i_city = document.getElementsByName("r_city")[1];

    var i_email = document.getElementsByName("r_email")[1];
    var i_phoneNumber = document.getElementsByName("r_phoneNumber")[1];
        

    var i_bt = document.getElementById("r_bloodType_clone");
    var i_r = document.getElementById("r_race_clone");
    var i_sex = document.getElementById("r_sex_clone");
    var i_pd = document.getElementById("r_primaryDiagnosys_clone");


    var receiver = {
        FirstName: i_fn.value,
        LastName: i_ln.value,
        Country: i_country.value,
        City: i_city.value,
        Age: i_age.value,
        Email: i_email.value,
        PhoneNumber: i_phoneNumber.value,
        Sex: i_sex.value,
        Race: i_r.value,
        BloodType: i_bt.value,
        PrimaryDiagnosis: i_pd.value
    }

    return receiver;
}

function save_sd_operations_data(elem){
    var subject_id = elem.parentNode.id.split("#")[1];
    var subject_type = elem.parentNode.id.split("#")[2];
    display_operations_confirmations_container("UPDATE_SUBJECT", subject_id, subject_type);
}


function reqGiverUpdate(id, body){
    var req = new XMLHttpRequest();
    req.open("PUT", ENDPOINTS.giverUpdate + "?id=" + id,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            close_operations_confirmations_container();
            close_sample_data_options();
            select_subject_tab("G");
            display_confirmation_message("The subject has been updated.");
        }else{
            display_error_message("An error has occured!");
        }
    }
    req.send(JSON.stringify(body));
}

function reqReceiverUpdate(id, body){
    var req = new XMLHttpRequest();
    req.open("PUT", ENDPOINTS.receiverUpdate + "?id=" + id,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            close_operations_confirmations_container();
            close_sample_data_options();
            select_subject_tab("R");
            display_confirmation_message("The subject has been updated.");
        }else{
            display_error_message("An error has occured!");
        }
    }
    req.send(JSON.stringify(body));
}


/*
    ### DELETE SUBJECT OPERATIONS
*/

function delete_sd_subject(elem){
    var subject_id = elem.parentNode.id.split("#")[1];
    var subject_type = elem.parentNode.id.split("#")[2];
    display_operations_confirmations_container("DELETE_SUBJECT", subject_id, subject_type);
}

function reqReceiverDelete(id){
    var req = new XMLHttpRequest();
    req.open("DELETE", ENDPOINTS.receiverDelete + "?id=" + id,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            close_operations_confirmations_container();
            close_sample_data_options();
            select_subject_tab("R");
            display_confirmation_message("The subject has been deleted.");
        }else{
            display_error_message("An error has occured!");
        }
    }
    req.send();
}

function reqGiverDelete(id){
    var req = new XMLHttpRequest();
    req.open("DELETE", ENDPOINTS.giverDelete + "?id=" + id,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            close_operations_confirmations_container();
            close_sample_data_options();
            select_subject_tab("G");
           display_confirmation_message("The subject has been deleted."); 
        }else{
            display_error_message("An error has occured!");
        }
    }
    req.send();
}

/*
    ### SAMPLE DATA OPERATIONS
*/
function display_data_sample_options(row){

    var background_container = document.getElementById("background_effect_sd_operations_id")
    background_container.style.display="block";

    var container = document.getElementById("sd_operations_input_id");

    var i_fn;
    var i_ln;
    var i_age;
    var i_sex;
    var i_country;
    var i_city;
    var i_email;
    var i_phoneNumber;
    var i_bt;
    var i_r;

    if(document.getElementById("sd_pd_id").style.display == "none"){
         document.getElementsByClassName("sd_operations_actions")[0].id = row.id + "#G";

        var giver_data = document.getElementById("register_giver_container_format_id").cloneNode(true);
        container.innerHTML = "";

        var select_input = giver_data.getElementsByTagName("select");
        for(var i=0;i<select_input.length;i++){
            select_input[i].id = select_input[i].id + "_clone";
        }
        container.innerHTML = giver_data.innerHTML;

        i_fn = document.getElementsByName("g_firstName")[1];
        i_ln = document.getElementsByName("g_lastName")[1];
        i_age = document.getElementsByName("g_age")[1];

        i_country = document.getElementsByName("g_country")[1];
        i_city = document.getElementsByName("g_city")[1];

        i_email = document.getElementsByName("g_email")[1];
        i_phoneNumber = document.getElementsByName("g_phoneNumber")[1];
        

        i_bt = document.getElementById("g_bloodType_clone");
        i_r = document.getElementById("g_race_clone");
        i_sex = document.getElementById("g_sex_clone");


    }else{
        document.getElementsByClassName("sd_operations_actions")[0].id = row.id + "#R";
        var receiver_data = document.getElementById("register_receiver_container_format_id").cloneNode(true);
        container.innerHTML = "";

        var select_input = receiver_data.getElementsByTagName("select");
        for(var i=0;i<select_input.length;i++){
            select_input[i].id = select_input[i].id + "_clone";
        }

        container.innerHTML = receiver_data.innerHTML;

        i_fn = document.getElementsByName("r_firstName")[1];
        i_ln = document.getElementsByName("r_lastName")[1];
        i_age = document.getElementsByName("r_age")[1];

        i_country = document.getElementsByName("r_country")[1];
        i_city = document.getElementsByName("r_city")[1];

        i_email = document.getElementsByName("r_email")[1];
        i_phoneNumber = document.getElementsByName("r_phoneNumber")[1];
        

        i_bt = document.getElementById("r_bloodType_clone");
        i_r = document.getElementById("r_race_clone");
        i_sex = document.getElementById("r_sex_clone");

        var i_pd = document.getElementById("r_primaryDiagnosys_clone");
        if(!set_select_options_by_value(i_pd, row.cells[11].innerHTML)){
            console.log("Check pd: " + row.cells[11].innerHTML )
        }
    }

    console.log(row);

    i_fn.value = row.cells[1].innerHTML;
    i_ln.value = row.cells[2].innerHTML;
    i_age.value = row.cells[5].innerHTML;
    i_country.value = row.cells[3].innerHTML;
    i_city.value = row.cells[4].innerHTML;
    i_email.value = row.cells[7].innerHTML;
    i_phoneNumber.value = row.cells[8].innerHTML;

    set_select_options_by_value(i_r, row.cells[9].innerHTML) == false ? console.log("Check race:" + row.cells[9].innerHTML) : "";
    set_select_options_by_value(i_bt, row.cells[10].innerHTML) == false ? console.log("Check bt: " + row.cells[10].innerHTML) : "";
    set_select_options_by_value(i_sex, row.cells[6].innerHTML) == false ? console.log("Check sex: " + row.cells[6].innerHTML) : "";
    
}

function set_select_options_by_value(elem, value){
    var options = elem.options;
    for(var i=0;i<options.length;i++){
        if(options[i].value === value){
            elem.selectedIndex = i;
            return true;
        }
    }
    return false;
}


function display_sample_data(data, subject){
    reinitialize_sample_data_table();
    var container = document.getElementById("sample_data_table_id");
    container.rows[0].style.height = "50px";

    if(subject == "G"){
        document.getElementById("sd_pd_id").style.display = "none";
    }else{
        document.getElementById("sd_pd_id").style.display = "block";
    }

    for(var i=0;i<data.length;i++){

        var row = document.createElement("tr");
        if(i%2 == 0){
            row.style.backgroundColor = "#dddddd";
        }

        row.style.height = "50px";

        var tdfn = document.createElement("td");
        var tdln = document.createElement("td");
        var tdcr = document.createElement("td");
        var tdct = document.createElement("td");
        var tdag = document.createElement("td");
        var tdsx = document.createElement("td");
        var tdem = document.createElement("td");
        var tdpn = document.createElement("td");
        var tdrc = document.createElement("td");
        var tdbt = document.createElement("td");

        var subject_operations = document.createElement("td");
        subject_operations.id = "SBJ#" + (i+1);
        subject_operations.innerHTML = "<i class='fa fa-info-circle'></i>";
        subject_operations.classList.add("sd_operations_info_btn");

        subject_operations.onclick = function() {
            display_data_sample_options(container.rows[parseInt(this.id.split("#")[1])]);
        };

        tdfn.innerHTML = data[i]['firstName'] ? data[i]['firstName'] : 'N/A';
        tdln.innerHTML = data[i]['lastName'] ? data[i]['lastName'] : 'N/A';
        tdcr.innerHTML = data[i]['country'] ? data[i]['country'] : 'N/A';
        tdct.innerHTML = data[i]['city'] ? data[i]['city'] : 'N/A';
        tdag.innerHTML = data[i]['age'] ? data[i]['age'] : 'N/A';
        tdsx.innerHTML = data[i]['sex'] ? data[i]['sex'] : 'N/A';
        tdem.innerHTML = data[i]['email'] ? data[i]['email'] : 'N/A';
        tdpn.innerHTML = data[i]['phoneNumber'] ? data[i]['phoneNumber'] : 'N/A';
        tdrc.innerHTML = data[i]['race'] ? data[i]['race'] : 'N/A';
        tdbt.innerHTML = data[i]['bloodType'] ? data[i]['bloodType'] : 'N/A';

        row.appendChild(subject_operations);
        row.appendChild(tdfn);
        row.appendChild(tdln);
        row.appendChild(tdcr);
        row.appendChild(tdct);
        row.appendChild(tdag);
        row.appendChild(tdsx);
        row.appendChild(tdem);
        row.appendChild(tdpn);
        row.appendChild(tdrc);
        row.appendChild(tdbt);

        if(subject == "R"){
            var tdpd = document.createElement("td");
            tdpd.innerHTML = data[i]['primaryDiagnosis'];
            row.appendChild(tdpd);
        }

        row.id = "SUBJECT#" + data[i]['id'];

        container.appendChild(row);
    }

}

function reqAllGivers(){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.giverGetAll,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            console.log(req.response);
            display_sample_data(JSON.parse(req.response), "G");
        }
    }
    req.send(null);
}


function reqAllReceivers(){
    var req = new XMLHttpRequest();
    req.open("GET", ENDPOINTS.receiverGetAll,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            console.log(req.response);
            display_sample_data(JSON.parse(req.response), "R");
        }
    }
    req.send(null);
}

function display_add_sample_tab(){
    document.getElementById("add_sample_data_background_effect_container_id").style.display="block";
    display_sd_giver_tab();
}

function close_add_sample_data_container(){
    document.getElementById("add_sample_data_background_effect_container_id").style.display="none";
}

function display_sd_generate_tab(){
    document.getElementById("register_giver_container_id").style.display="none";
    document.getElementById("register_receiver_container_id").style.display="none";
    document.getElementById("generate_sample_data_container_id").style.display="block";
}

function display_sd_giver_tab(){
    document.getElementById("register_receiver_container_id").style.display="none";
    document.getElementById("generate_sample_data_container_id").style.display="none";
    document.getElementById("register_giver_container_id").style.display="block";
    document.getElementById("add_sample_reg_giver_option_id").classList.add("add_sample_active_option");
    document.getElementById("add_sample_reg_receiver_option_id").classList.remove("add_sample_active_option");
    /*.add_sample_active_option*/
}

function display_sd_receiver_tab(){
    document.getElementById("generate_sample_data_container_id").style.display="none";
    document.getElementById("register_giver_container_id").style.display="none";
    document.getElementById("register_receiver_container_id").style.display="block";
    document.getElementById("add_sample_reg_giver_option_id").classList.remove("add_sample_active_option");
    document.getElementById("add_sample_reg_receiver_option_id").classList.add("add_sample_active_option");
}

function register_giver_functionality(){
    var gv_fn = document.getElementsByName("g_firstName")[0].value;
    var gv_ln = document.getElementsByName("g_lastName")[0].value;
    var gv_age = document.getElementsByName("g_age")[0].value;
    
    var gv_sex_index = document.getElementById("g_sex");
    var gv_sex = gv_sex_index.options[gv_sex_index.selectedIndex].value;

    var gv_country = document.getElementsByName("g_country")[0].value;
    var gv_city = document.getElementsByName("g_city")[0].value;

    var gv_email = document.getElementsByName("g_email")[0].value;
    var gv_phoneNumber = document.getElementsByName("g_phoneNumber")[0].value;
    

    var gv_bt_index = document.getElementById("g_bloodType");
    var gv_bt = gv_bt_index.options[gv_bt_index.selectedIndex].value;


    var gv_r_index = document.getElementById("g_race");
    var gv_r = gv_r_index.options[gv_r_index.selectedIndex].value;


    if(
        gv_fn == '' ||
        gv_ln == '' ||
        gv_age == ''
    ){
       display_error_message( "The following fields must be completed: first name, last name, sex, blood type.");
    }else{


        giver = {
            FirstName: gv_fn,
            LastName: gv_ln,
            Age: gv_age,
            Sex: gv_sex.toUpperCase(),
            Country: gv_country,
            City: gv_city,
            Email: gv_email,
            PhoneNumber: gv_phoneNumber,
            BloodType: gv_bt,
            Race: gv_r.toUpperCase()
        }

        reqGiverRegister(giver);
    }
}

function register_receiver_functionality(){
    var rv_fn = document.getElementsByName("r_firstName")[0].value;
    var rv_ln = document.getElementsByName("r_lastName")[0].value;
    var rv_age = document.getElementsByName("r_age")[0].value;
    
    var rv_sex_index = document.getElementById("r_sex");
    var rv_sex = rv_sex_index.options[rv_sex_index.selectedIndex].value;

    var rv_country = document.getElementsByName("r_country")[0].value;
    var rv_city = document.getElementsByName("r_city")[0].value;

    var rv_email = document.getElementsByName("r_email")[0].value;
    var rv_phoneNumber = document.getElementsByName("r_phoneNumber")[0].value;
    

    var rv_bt_index = document.getElementById("r_bloodType");
    var rv_bt = rv_bt_index.options[rv_bt_index.selectedIndex].value;


    var rv_r_index = document.getElementById("r_race");
    var rv_r = rv_r_index.options[rv_r_index.selectedIndex].value;

    var rv_pd_index = document.getElementById("r_primaryDiagnosys");
    var rv_pd = rv_pd_index.options[rv_pd_index.selectedIndex].value;

    if(
        rv_fn == '' ||
        rv_ln == '' ||
        rv_age == ''
    ){
       display_error_message( "The following fields must be completed: first name, last name, sex, blood type.");
    }else{


        receiver = {
            FirstName: rv_fn,
            LastName: rv_ln,
            Age: rv_age,
            Sex: rv_sex.toUpperCase(),
            Country: rv_country,
            City: rv_city,
            Email: rv_email,
            PhoneNumber: rv_phoneNumber,
            BloodType: rv_bt,
            Race: rv_r.toUpperCase(),
            PrimaryDiagnosis: rv_pd.toUpperCase()
        }

        reqReceiverRegister(receiver);
    }

}


function display_confirmation_message(message){
    document.getElementById("message_container_background_id").style.display="block";
    document.getElementById("confirmation_container_id").style.display="block";
    document.getElementById("confirmation_container_message_id").innerText = message;
}

function display_error_message(message){
    document.getElementById("message_container_background_id").style.display="block";
    document.getElementById("error_container_id").style.display="block";
    document.getElementById("error_container_message_id").innerText = message;     
}

function reqGiverRegister(body){
    var req = new XMLHttpRequest();
    req.open("POST", ENDPOINTS.giverRegister,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            var data = JSON.parse(req.response);
            display_confirmation_message("Subject " + data['firstName'] + " " + data['lastName'] + " is registered.");
        }else{
            display_error_message("An error occured on server side.");
        }
    }
    req.send(JSON.stringify(body));
}


function reqReceiverRegister(body){
    var req = new XMLHttpRequest();
    req.open("POST", ENDPOINTS.receiverRegister,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            var data = JSON.parse(req.response);
            display_confirmation_message("Subject " + data['firstName'] + " " + data['lastName'] + " is registered.");
        }else{
            display_error_message("An error occured on server side.");
        }
    }
    req.send(JSON.stringify(body));
}


function filter_data_functionality(){

    var filterType = "G";

    var filter_fn = document.getElementsByName("filter_fn")[0].value;
    var filter_ln = document.getElementsByName("filter_ln")[0].value;
    var filter_country = document.getElementsByName("filter_country")[0].value;
    var filter_age = document.getElementsByName("filter_age")[0].value;
    var filter_city = document.getElementsByName("filter_city")[0].value;
    var filter_race = document.getElementsByName("filter_race")[0].value;
    var filter_sex = document.getElementsByName("filter_sex")[0].value;
    var filter_bt = document.getElementsByName("filter_bt")[0].value;

    var filter_pd = document.getElementsByName("filter_pd")[0];


    var filter_obj = {
        FirstName: filter_fn,
        LastName: filter_ln,
        Age: filter_age,
        Country: filter_country,
        City: filter_city,
        Race: filter_race,
        Sex: filter_sex,
        BloodType: filter_bt,
        SortData: {
            Field: 'FIRST_NAME',
            Order: 1
        },
        PaginationData: {
            Skip: 0,
            Limit: 50
        }
    };

    if(filter_pd.style.display=="block"){
        filter_pd = filter_pd.value;
        filterType = "R";
        filter_obj.PrimaryDiagnosis = filter_pd;
    }

    if(filterType == "R"){
        reqReceiverFilter(filter_obj);
    }else{
        console.log(filter_obj);
        reqGiverFilter(filter_obj);
    }
    

}



function reqGiverFilter(body){
    var req = new XMLHttpRequest();
    req.open("POST", ENDPOINTS.giverFilter,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            var data = JSON.parse(req.response);
            if(data.length != 0){
                console.log(data);
                display_confirmation_message("Filtered data are loaded in Sample Data tab.")
                display_sample_data(data, "G");
            }else{
                display_error_message("No data has been found with given inputs.")
            }
        }else{
            display_error_message("An error occured on server side.")
        }
    }
    req.send(JSON.stringify(body));
}


function reqReceiverFilter(body){
    var req = new XMLHttpRequest();
    req.open("POST", ENDPOINTS.receiverFilter,true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.onreadystatechange = function(){
        if(req.readyState == 4 && req.status == 200){
            var data = JSON.parse(req.response);
            if(data.length != 0){
                console.log(data);
                display_confirmation_message("Filtered data are loaded in Sample Data tab.")
                display_sample_data(data, "R");
            }else{
                display_error_message("No data have been found with given filter params.")
            }
        }else{
            display_error_message("An error occured on server side.")
        }
    }
    req.send(JSON.stringify(body));
}
function open_container(container){

    document.getElementById('visualization_container').style.display = "none";
    document.getElementById('optimal_assigment_container').style.display = "none";
    document.getElementById('sample_data_container').style.display = "none";

    document.getElementById("menu_comp_btn_id").classList.remove("active_cbutton");
    document.getElementById("menu_op_btn_id").classList.remove("active_cbutton");
    document.getElementById("menu_sd_btn_id").classList.remove("active_cbutton");
    
    if(container == 'COMPATIBILITIES'){
        document.getElementById("menu_comp_btn_id").classList.add("active_cbutton");
        document.getElementById('visualization_container').style.display = "block";

    }

    if(container == 'OPTIMAL_ASSIGMENT'){
        document.getElementById("menu_op_btn_id").classList.add("active_cbutton");
        document.getElementById('optimal_assigment_container').style.display = "block";
    }

    if(container == 'SAMPLE_DATA'){
        document.getElementById("menu_sd_btn_id").classList.add("active_cbutton");
        document.getElementById('sample_data_container').style.display = "block";
    }
}


function close_bcontainer(){
    document.getElementById("background_container_id").style.display = "none";
}


function display_intro_container(){
    document.getElementById("main_container").style.display="none";
    document.getElementById("top_container_id").style.display="block";
}
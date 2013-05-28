function Toggel(id)
{
    if (document.getElementById(id).style.visibility == 'visible') {
        document.getElementById(id).style.visibility = 'hidden';
        document.getElementById("LogToggelbtn").value = "Logg inn";
    }
    else {
        document.getElementById(id).style.visibility = 'visible';
        document.getElementById("LogToggelbtn").value = "Skjul";
    }
    }

function ValidateAddProductForm() {
    var text;

    var quantity = document.getElementById("Quantity").value;
    if (quantity == 0) {
        text = "the Quantity Can Not be  0";
        document.getElementById("demo").innerHTML = text;
        document.getElementById("Quantity").focus();
        document.getElementById("Quantity").style.backgroundColor = "red";

        return false;
    }
    var price = document.getElementById("Price").value;
    if (price == 0) {
        text = "The Price Can Not be  0";
        document.getElementById("demo").innerHTML = text;
        document.getElementById("Price").focus();
        document.getElementById("Price").style.backgroundColor = "red";
        return false;
    }
    if (document.getElementById("SubCatagoryName").value == "Book")
    {
        var No_page = document.getElementById("No_page").value;
        if (No_page == 0) {
            text = "The No_page Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("No_page").focus();
            document.getElementById("No_page").style.backgroundColor = "red";
            return false;
    }
    }
    if (document.getElementById("SubCatagoryName").value == "Computer") {
        var CPU = document.getElementById("CPU").value;
        if (CPU == 0) {
            text = "The CPU Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("CPU").focus();
            document.getElementById("CPU").style.backgroundColor = "red";
            return false;
        }
        var RAM = document.getElementById("RAM").value;
        if (RAM == 0) {
            text = "The RAM Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("RAM").focus();
            document.getElementById("RAM").style.backgroundColor = "red";
            return false;
        }

        var Processer_Speed = document.getElementById("Processer_Speed").value;
        if (Processer_Speed == 0) {
            text = "The Processer_Speed Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Processer_Speed").focus();
            document.getElementById("Processer_Speed").style.backgroundColor = "red";
            return false;
        }
        var Hard_Disk = document.getElementById("Hard_Disk").value;
        if (Hard_Disk == 0) {
            text = "the Hard_Disk Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Hard_Disk").focus();
            document.getElementById("Hard_Disk").style.backgroundColor = "red";

            return false;
        }
        var Size = document.getElementById("Size").value;
        if (Size == 0) {
            text = "the Size Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Size").focus();
            document.getElementById("Size").style.backgroundColor = "red";

            return false;
        }
        var Storage = document.getElementById("Storage").value;
        if (Storage == 0) {
            text = "the Storage Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Storage").focus();
            document.getElementById("Storage").style.backgroundColor = "red";

            return false;
        }

    }
    if (document.getElementById("SubCatagoryName").value == "Phone") {
        var SIM_NO = document.getElementById("SIM_NO").value;
        if (SIM_NO == 0) {
            text = "the SIM_NO Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("SIM_NO").focus();
            document.getElementById("SIM_NO").style.backgroundColor = "red";

            return false;
        }
        var Display = document.getElementById("Display").value;
        if (Display == 0) {
            text = "the Display Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Display").focus();
            document.getElementById("Display").style.backgroundColor = "red";

            return false;
        }
        var Main_Camer = document.getElementById("Main_Camer").value;
        if (Main_Camer == 0) {
            text = "the Main_Camer Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Main_Camer").focus();
            document.getElementById("Main_Camer").style.backgroundColor = "red";

            return false;
        }
        var Front_Camer = document.getElementById("Front_Camer").value;
        if (Front_Camer == 0) {
            text = "the Front_Camer Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Front_Camer").focus();
            document.getElementById("Front_Camer").style.backgroundColor = "red";

            return false;
        }
    }
    if (document.getElementById("SubCatagoryName").value == "Car") {
        var Capacity = document.getElementById("Capacity").value;

        if (Capacity == 0) {
            text = "the Capacity Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Capacity").focus();
            document.getElementById("Capacity").style.backgroundColor = "red";

            return false;
        }
    }
    if (document.getElementById("SubCatagoryName").value == "House") {
        var Nobedroom = document.getElementById("Nobedroom").value;
        if (Nobedroom == 0) {
            text = "the No_bedroom Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Nobedroom").focus();
            document.getElementById("Nobedroom").style.backgroundColor = "red";

            return false;
        }
        var Bathroom = document.getElementById("Bathroom").value;

        if (Bathroom == 0) {
            text = "the Bathroom Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Bathroom").focus();
            document.getElementById("Bathroom").style.backgroundColor = "red";

            return false;
        }
        var Total_room = document.getElementById("Total_room").value;
        if (Total_room == 0) {
            text = "the Total_room Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("Total_room").focus();
            document.getElementById("Total_room").style.backgroundColor = "red";

            return false;
        }

    }
    if (document.getElementById("SubCatagoryName").value == "Cloth") {
        var SizeofCloth = document.getElementById("SizeofCloth").value;
        if (SizeofCloth == 0) {
            text = "the SizeofCloth Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("SizeofCloth").focus();
            document.getElementById("SizeofCloth").style.backgroundColor = "red";

            return false;
        }
    }
    if (document.getElementById("SubCatagoryName").value == "Computer") {
        var ShoseSize = document.getElementById("ShoseSize").value;
        if (ShoseSize == 0) {
            text = "the ShoseSize Can Not be  0";
            document.getElementById("demo").innerHTML = text;
            document.getElementById("ShoseSize").focus();
            document.getElementById("ShoseSize").style.backgroundColor = "red";

            return false;
        }
    }
    else {

        return true;
    }
}
function onlynum(evt) {
    var ch = String.fromCharCode(evt.which);
    if (!(/[0-9]/.test(ch))) {
        evt.preventDefault();
    }

}
function onlyIntAndDuble(evt) {
    var ch = String.fromCharCode(evt.which);
    if (!(/[0.0-9.0]/.test(ch))) {
        evt.preventDefault();
    }

}

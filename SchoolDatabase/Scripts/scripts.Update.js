function updateTeacher() {

    var teacher = document.getElementById("changeTeacher").value;
    alert("You are updating teacher #" + teacher);

    //goal: send a request to http://localhost:64219/Teacher/Update/{id}

    var URL = "http://localhost:64219/Teacherdata/Update/"+teacher;

    var newRequest = new XMLHttpRequest();

    newRequest.open("POST", URL);
    newRequest.onreadystatechange = function() {
        //ready state should be 4 and the status should be 200
        if (newRequest.readyState==4 && newRequest.status==200) {
            //Request is successful and request is finished

            var teacherText = JSON.parse(newRequest.responseText);

            console.log(teacherText.teacherid);
            console.log(teacherText.TeacherFname);
            console.log(teacherText.TeacherLname);
            console.log(teacherText.EmployeeNumber);
            console.log(teacherText.HireDate);
            console.log(teacherText.Salary);

            //Client-Side Rendering
            document.getElementById("teacherid").innerHTML = teacherText.teacherid;
            document.getElementById("teacherfname").innerHTML = teacherText.TeacherFname;
            document.getElementById("teacherlname").innerHTML = teacherText.TeacherLname;
            document.getElementById("employeenumber").innerHTML = teacherText.EmployeeNumber;
            document.getElementById("hiredate").innerHTML = teacherText.HireDate;
            document.getElementById("salary").innerHTML = teacherText.Salary;
            
        }
    }

    newRequest.send();


};
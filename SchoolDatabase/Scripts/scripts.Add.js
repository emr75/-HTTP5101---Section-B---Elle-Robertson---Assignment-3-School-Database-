function addTeacher() {

    var teacher = document.getElementById("addTeacher");
    alert("You are adding " + teacher);

    //goal: send a request to http://localhost:64219/Teacher/Add/

    var URL = "http://localhost:64219/api/Teacherdata/AddTeacher";

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
            // document.forms.addForm.teacherid = teacherText.teacherid;
            // document.forms.addForm.teacherfname = teacherText.TeacherFname;
            // document.forms.addForm.teacherlname = teacherText.TeacherLname;
            // document.forms.addForm.employeenumber = teacherText.EmployeeNumber;
            // document.forms.addForm.hiredate = teacherText.HireDate;
            // document.forms.addForm.salary = teacherText.Salary;

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
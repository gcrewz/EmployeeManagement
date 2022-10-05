// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*$(document).ready(function () {
    bindEvents();
    
});

function bindEvents() {
    $(".employeeEdit").on("click", function (event) {
        console.log("clicked");
        var employeeId = event.currentTarget.getAttribute("data-id");
        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $("#empId").val(result.id)
                $("#empName").val(result.name)
                $("#empDept").val(result.department)
                $("#empAge").val(result.age)
                $("#empAddress").val(result.address)
            },
            error: function (error) {
                console.log(error);
            }
        });
        $("#updateform").submit(function (event) {
            console.log("clicked");
            var idUpdate = $("#empId").val();
            var nameUpdate = $("#empName").val();
            var departmentUpdate = $("#empDept").val();
            var ageUpdate = $("#empAge").val();
            var addressUpdate = $("#empAddress").val();
            let employees = {
                id: parseInt(idUpdate),
                name: nameUpdate,
                department: departmentUpdate,
                age: parseInt(ageUpdate),
                address: addressUpdate
            };
            $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                url: 'https://localhost:44383/api/internal/employee/update',
                type: 'PUT',
                data: JSON.stringify(employees),
                dataType: 'json',
                success: function (result) {
                    location.reload();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });
*///}
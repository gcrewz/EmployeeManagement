$(document).ready(function () {
    bindEvents();
    hideEmployeeDetailCard();
});


//Ajax Details Of Employee

function bindEvents() {
    $(".employeeDetails").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var newEmployeeCard = `<div class="card">
                                          <h1>${result.name}</h1>
                                         <b>Id :</b> <p>${result.id}</p>
                                         <b>Department:</b><p>${result.department}</p>
                                         <b>Age:</b><p>${result.age}</p>
                                         <b>Address:</b><p>${result.address}</p>
                                        </div>`

                $("#EmployeeCard").html(newEmployeeCard);
                showEmployeeDetailCard();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });


    /*$("#createform").submit(function (event) {

        var employeeDetailedViewModel = {};

        employeeDetailedViewModel.Name = $("#name"/).val();
        employeeDetailedViewModel.Department = $("#dept"/).val();
        employeeDetailedViewModel.Age = Number($("#age"/).val());
        employeeDetailedViewModel.Address = $("#address"/).val();

        var data = JSON.stringify(employeeDetailedViewModel);

        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/insert-employee',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {

                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });*/


    //Ajax INSERT Employee

    $("#createform").submit(function (event) {

        var employeeDetailedViewModel = {};

        employeeDetailedViewModel.Name = $("#name").val();
        employeeDetailedViewModel.Department = $("#dept").val();
        employeeDetailedViewModel.Age = Number($("#age").val());
        employeeDetailedViewModel.Address = $("#address").val();

        var data = JSON.stringify(employeeDetailedViewModel);

        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/insert',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });


    //Ajax Update Employee


    $("#updateform").submit(function (event) {



        var employeeDetailedViewModel = {};



        employeeDetailedViewModel.Id = Number($("#empId").val());
        employeeDetailedViewModel.Name = $("#empName").val();
        employeeDetailedViewModel.Department = $("#empDept").val();
        employeeDetailedViewModel.Age = Number($("#empAge").val());
        employeeDetailedViewModel.Address = $("#empAddress").val();



        var data = JSON.stringify(employeeDetailedViewModel);



        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/update',
            type: 'PUT',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                location.reload(true);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });


    //Ajax Delete Employee

    $(".employeeDelete").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        var result = confirm("Are You Sure You Want To Delete?");
        if (result) {
            alert("Successfully deleted the data");

            $.ajax({
                url: 'https://localhost:44383/api/internal/employee/' + employeeId,
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    location.reload();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
        else {
            alert("Deletion Canceled");
        }
    });

}

 
function hideEmployeeDetailCard() {
    $("#EmployeeCard").hide();
}

function showEmployeeDetailCard() {
    $("#EmployeeCard").show();
}
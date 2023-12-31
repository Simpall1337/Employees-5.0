document.addEventListener('DOMContentLoaded', function() {
    var changeForm = document.getElementById('changeForm');
    var messageElement = document.getElementById('message');
    var button1 = document.getElementById('button1');



    button1.addEventListener('click', function() {
        window.location.href = "main.html";
      });
    changeForm.addEventListener('submit', function(event) {
        event.preventDefault(); 

        var managerId = document.getElementById('ManagerId').value || null;
        var name = document.getElementById('Name').value|| null;
        var surname = document.getElementById('Surname').value|| null; 
        var patronymic = document.getElementById('Patronymic').value|| null; 
        var birthday = document.getElementById('Birthday').value|| null; 
        var education = document.getElementById('Education').value|| null; 
        var position = document.getElementById('Position').value|| null; 
        var salary = document.getElementById('Salary').value|| null; 
        var departmentid = document.getElementById('Department_id').value|| null; 
        var id = document.getElementById('id').value;
        var flag = document.getElementById('select').checked|| null;
        if(flag == null)
        flag = false;

        var data = {
            managerId: managerId,
            name: name,
            surname: surname,
            patronymic: patronymic,
            birthday: birthday,
            education: education,
            position: position,
            salary: salary,
            departmentid: departmentid
        };

        fetch(`https://localhost:5001/employee?id=${id}&changeManagerId=${flag}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(function(response) {
            if (response.ok) {
                messageElement.textContent = 'Дані успішно зміненні.';
                messageElement.style.color = 'green';
            } else {
                messageElement.textContent = 'Помилка при введені даних.';
                messageElement.style.color = 'red';
            }
        })
        .catch(function(error) {
            console.log(error);
            messageElement.textContent = 'Сталася помилка при виконані запиту.';
            messageElement.style.color = 'red';
        });
    });
});
document.addEventListener('DOMContentLoaded', function() {
    var changeForm = document.getElementById('addForm');
    var messageElement = document.getElementById('message');
    var button1 = document.getElementById('button1');



    button1.addEventListener('click', function() {
        window.location.href = "main.html";
      });
    changeForm.addEventListener('submit', function(event) {
        event.preventDefault(); 

        var managerId = document.getElementById('ManagerId').value || null;
        var name = document.getElementById('Name').value;
        var surname = document.getElementById('Surname').value; 
        var patronymic = document.getElementById('Patronymic').value; 
        var birthday = document.getElementById('Birthday').value; 
        var education = document.getElementById('Education').value; 
        var position = document.getElementById('Position').value; 
        var salary = document.getElementById('Salary').value; 
        var departmentid = document.getElementById('Department_id').value; 

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

        fetch('https://localhost:5001/employee', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(function(response) {
            if (response.ok) {
                messageElement.textContent = 'Дані успішно введені.';
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
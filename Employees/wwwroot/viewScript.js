 
document.addEventListener('DOMContentLoaded', function() {
   
    let changeForm = document.getElementById('viewForm');
    let messageElement = document.getElementById('message');
    let button1 = document.getElementById('button1');
    let cl = document.getElementById('message');
       
    button1.addEventListener('click', function() {
        window.location.href = "main.html";
      });
    changeForm.addEventListener('submit', function(event) {
        event.preventDefault(); 

        let managerId = document.getElementById('ManagerId').value || null;
        let name = document.getElementById('Name').value|| null;
        let surname = document.getElementById('Surname').value|| null; 
        let patronymic = document.getElementById('Patronymic').value|| null; 
        let birthday = document.getElementById('Birthday').value|| null; 
        let education = document.getElementById('Education').value|| null; 
        let position = document.getElementById('Position').value|| null; 
        let salary = document.getElementById('Salary').value|| null; 
        let departmentid = document.getElementById('Department_id').value|| null; 
        let id = document.getElementById('id').value|| null;
    
        let queryString = '?';

        queryString += id !== null ? `id=${id}&` : '';
        queryString += managerId !== null ? `managerId=${managerId}&` : '';
        queryString += name !== null ? `name=${name}&` : '';
        queryString += surname !== null ? `surname=${surname}&` : '';
        queryString += patronymic !== null ? `patronymic=${patronymic}&` : '';
        queryString += birthday !== null ? `birthday=${birthday}&` : '';
        queryString += education !== null ? `education=${education}&` : '';
        queryString += position !== null ? `position=${position}&` : '';
        queryString += salary !== null ? `salary=${salary}&` : '';
        queryString += departmentid !== null ? `departmentid=${departmentid}&` : '';

        // Удалите последний символ '&' из строки запроса, если он есть
        if (queryString.endsWith('&')) {
            queryString = queryString.slice(0, -1);
        }

       // const messageElement = document.querySelector('.employeeTable');
      //  console.log(messageElement);
        // async function getData(){
        //  const data = await axios.get(`https://localhost:5001/employee${queryString}`)
         
        // return data.data;
        // }

        fetch(`https://localhost:5001/employee${queryString}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response =>{
            return response.json();
        }
        ).then(data => {
            const slicedData = data.slice(); 
           
            console.log(slicedData);
            cl.innerHTML =  markup(slicedData);
        })
       //const get = getData();
       
       function markup(item){
        return item.map(element => {
            return `
            <div style='border: 1px solid black'>Номер робітника: ${element.id}</div>
            <div style='border: 1px solid black'>Номер керівника: ${element.managerId}</div>
            <div style='border: 1px solid black'>Ім'я: ${element.name}</div>
            <div style='border: 1px solid black'>Прізвище: ${element.surname}</div>
            <div style='border: 1px solid black'>По-батькові: ${element.patronymic}</div>
            <div style='border: 1px solid black'>Дата народження: ${element.birthday}</div>
            <div style='border: 1px solid black'>Освіта: ${element.education}</div>
            <div style='border: 1px solid black'>Позиція: ${element.position}</div>
            <div style='border: 1px solid black'>Оклад: ${element.salary}</div>
            <div style='border: 1px solid black'>Департамент: ${element.departmentId}</div>
            `
        }).join(' ')}
       //markup(get);
    });
});
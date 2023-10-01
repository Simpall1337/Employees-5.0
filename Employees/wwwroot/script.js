document.addEventListener('DOMContentLoaded', function() {
    var button1 = document.getElementById('button1');
    var button2 = document.getElementById('button2');
    var button3 = document.getElementById('button3');

    button1.addEventListener('click', function() {
      window.location.href = "add.html";
    });
    button2.addEventListener('click', function() {
      window.location.href = "change.html";
    });
    button3.addEventListener('click', function() {
      window.location.href = "delete.html";
    });
    button4.addEventListener('click', function() {
        window.location.href = "view.html";
      });
    
  });
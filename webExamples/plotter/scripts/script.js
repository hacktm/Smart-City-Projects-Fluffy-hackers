function draw(data) {
  var ctx = document.getElementsByTagName('canvas')[0].getContext('2d');
  var radius = 7;
  ctx.lineWidth = 5;
  ctx.lineJoin = 'round';
  for(var i = 0; i < data.length; i++) {
    var x = data[i][0];
    var y = data[i][1];

    ctx.fillStyle = 'red';
    ctx.beginPath();
    ctx.arc(x, y, radius, 0, Math.PI * 2, true);
    ctx.fill();
    ctx.closePath();
    ctx.strokeStyle = 'red';
    ctx.stroke();
  }

  for(var i = 0; i < data.length - 1; i++) {
    var x = data[i][0];
    var y = data[i][1];

    var xNext = data[i + 1][0];
    var yNext = data[i + 1][1];

    ctx.beginPath();
    ctx.moveTo(x, y);
    ctx.lineTo(xNext, yNext);
    ctx.strokeStyle = 'red';
    ctx.stroke();
    ctx.closePath();
  }
}

function clear() {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.height, canvas.width);
    var w = canvas.width;
    canvas.width = 1;
    canvas.width = w;
}

$( document ).ready(function() {
  draw([[10,10],[20,50],[100,70]]);
  window.setTimeout(clear,10000);
});
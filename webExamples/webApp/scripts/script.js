var canvas;
var ctx;
var color = 'yellow';
var points = [];
var validator = new DollarRecognizer();

//------------------------------------------------------------------------------
function initPubNub() {
  var pub = PUBNUB.init({
    publish_key: 'pub-c-af0c28d6-36d3-4667-bd7b-707dc6e07515',
    subscribe_key: 'sub-c-a7b31746-56d3-11e4-a7f8-02ee2ddab7fe'
  });
  pub.subscribe({
    channel: 'fluffy',
    message: function(m){
      console.log(m);
      if(m.length > 1) {
        var values = m.split(',');
        point(parseInt(values[0]), parseInt(values[1]));
        points.push(new Point(parseInt(values[0]), parseInt(values[1])));
      } else {
        validate();
        // activate this in order to store the data to the LocalStorage
        //store();
      }
    }
  });
}

//------------------------------------------------------------------------------
function point(x, y) {
  ctx.beginPath();
  ctx.arc(x/2, y/2, 5, 0, 2 * Math.PI, true);

  ctx.fillStyle = color;
  ctx.fill();
  ctx.strokeStyle = color;
  ctx.stroke();
}

function clear() {
  ctx.clearRect(0, 0, window.innerWidth, window.innerHeight);
}

function initCanvas() {
  canvas = document.getElementById("myCanvas");
  ctx = canvas.getContext("2d");
  ctx.canvas.width  = window.innerWidth;
  ctx.canvas.height = window.innerHeight;
}

function openDoor() {
  $("#slidingDoors").addClass('swing');
}

//------------------------------------------------------------------------------
function clearpoints() {
  points = [];
}

function validate() {
  var result = validator.Recognize(points, false);
  console.log("result of test : " + result.Name + " score " + result.Score);

  // also added pigtail to the result detection because it's similar to circle
  if((result.Name === "circle" || result.Name === "pigtail" || result.Name === "triangle") && result.Score > 0.4) {
    console.log("PASSWORD ACCEPTED!");
    openDoor();
  }
  // after validation we need to clear the points + erase the canvas after a
  // 5 second timeout
  clearpoints();
  window.setTimeout(clear,5000);
}

function displayPoints() {
  for(var i = 0; i < points.length ; i++) {
    console.log(points[i].X + " " + points[i].Y);
    point(points[i].X, points[i].Y);
  }
}

function store() {
  localStorage.setItem('points', JSON.stringify(points));
}

function testValidate() {
  points = JSON.parse(localStorage.getItem('points'));
  console.log("read local storage : " + points.length);
  displayPoints();
  validate();
}

$( document ).ready(function() {
  initCanvas();
  initPubNub();

  //testValidate();
  //window.setTimeout(clear,1000);
});
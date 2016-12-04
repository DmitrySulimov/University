function Brush(context){
  this.context = context;
  this.radius = 0;
  this.width = 0;
  this.height = 0;
  this.fillColor = 'black';
  this.x  = undefined;
  this.y = undefined;
  this.painting = false;
  this.selectedTool = 'pencil';
}

Brush.prototype = {
  drawRect: function(movedX, movedY){
    this.context.fillStyle = this.fillColor;
    this.context.lineWidth = 1;

    this.width = movedX - this.x;
    this.height = movedY - this.y;
    this.context.rect(this.x, this.y, this.width, this.height);
  },
  drawCircle: function(movedX, movedY){
    this.context.fillStyle = this.fillColor;
    this.context.lineWidth = 1;

    this.width = Math.abs(movedX - this.x);
    this.height = Math.abs(movedY - this.y);
    this.context.ellipse(this.x, this.y, this.width, this.height, 2 * Math.PI, 0, 8);
  },
  drawPencil: function(newX, newY){
    this.context.strokeStyle = this.fillColor;
    this.context.lineWidth = this.radius;
    this.context.lineCap = 'round';

    this.context.beginPath();
    this.context.moveTo(this.x, this.y);
    this.context.lineTo(newX, newY);


    this.x = newX;
    this.y = newY; 
	this.context.stroke();
  },
  
   drawSpray: function(newX, newY){ 
	this.context.fillStyle = this.fillColor; 
	this.context.lineWidth = this.radius; 

	this.context.beginPath(); 
	this.context.moveTo(this.x, this.y); 
	this.context.fillRect(newX, newY, 1, 1, 25); 

	for (var i = 20; i--;) { 
	this.context.fillRect(newX + Math.random() * 20 - 10, 
	newY + Math.random() * 20 - 10, 1, 1, 25) ;} 
	this.context.fill(); 

	this.x = newX; 
	this.y = newY; 
},
  drawLine: function(endX, endY){
    this.context.strokeStyle = this.fillColor;
    this.context.lineWidth = this.radius;
    this.context.lineCap = 'round';

    this.context.moveTo(this.x, this.y);
    this.context.lineTo(endX, endY);
	this.context.fill();
  },
  erase: function(newX, newY){
    this.context.lineWidth = this.radius;
    this.context.globalCompositeOperation="destination-out";
    this.context.beginPath();
    this.context.moveTo(this.x, this.y);
    this.context.lineTo(newX, newY);
    this.context.fill();

    this.x = newX;
    this.y = newY;
  },
  startDrawing: function(newX, newY){
    this.context.globalCompositeOperation="source-over";
    this.context.beginPath();
    this.x = newX;
    this.y = newY;
    this.width = 0;
    this.height = 0;
    this.painting = true;
  },
  stopDrawing: function(){
    this.context.fill();
    this.painting = false;
    this.x = undefined;
    this.y = undefined;
    this.width = 0;
    this.height = 0;
  }
}

function Painter(canvas){
  var context = canvas.getContext('2d');
  var imgData;

  var brush = new Brush(context);
  brush.radius = 1;
  brush.color = "#000";

  var cancel = function(e){
    e.preventDefault();
    return false;
  }

  this.upListener = function(e){
    if(brush.painting){
      var x = e.offsetX;
      var y = e.offsetY;
    }
    brush.stopDrawing();
    imgData = context.getImageData(0, 0, canvas.width, canvas.height);
  }

  this.downListener = function(e){
    var x = e.offsetX;
    var y = e.offsetY;
    imgData = undefined;
    brush.startDrawing(x, y);
    this.draw(e);
  }.bind(this);

  this.moveListener = function(e){
    this.draw(e);
  }.bind(this);

  this.draw = function(e){
    var x = e.offsetX;
    var y = e.offsetY;

    context.beginPath();
    if(brush.painting){
      switch(brush.selectedTool){
        case 'pencil':{
          brush.drawPencil(x, y);
          break;
        }
		 case 'spray':{
          if(imgData!= undefined) context.putImageData(imgData, 0, 0);
          brush.drawSpray(x, y);
          imgData = context.getImageData(0, 0, canvas.width, canvas.height);
          break;
        }
        case 'line':{
          if(imgData!= undefined) context.putImageData(imgData, 0, 0);
          brush.drawLine(x, y);
          imgData = context.getImageData(0, 0, canvas.width, canvas.height);
          break;
        }
        case 'rectangle':{
          if(imgData!= undefined) context.putImageData(imgData, 0, 0);
          brush.drawRect(x, y);
          imgData = context.getImageData(0, 0, canvas.width, canvas.height);
          break;
        }
        case 'circle':{
          if(imgData!= undefined) context.putImageData(imgData, 0, 0);
          brush.drawCircle(x, y);
          imgData = context.getImageData(0, 0, canvas.width, canvas.height);
          break;
        }
        case 'eraser':{
          brush.erase(x, y);
          break;
        }
        default:
        break;
      }
    }
    context.stroke();
  }

  canvas.addEventListener('mousedown', this.downListener);
  document.addEventListener('mouseup', this.upListener);
  canvas.addEventListener('mousemove', this.moveListener);
  canvas.addEventListener('contextmenu', this.cancel);
  canvas.addEventListener('selectstart', this.cancel);

  var fillColorInput = document.getElementById('stroke-color');
  fillColorInput.onchange = function(e){
    brush.fillColor = fillColorInput.value;
  };

  var thicknessInput = document.getElementById('tool-thickness');
  thicknessInput.onchange = function(e){
    brush.radius = thicknessInput.value;
  }

  var tools = document.getElementsByName('tool');
  for(var i = 0; i < tools.length; i++){
    tools[i].onchange = function(e){
      console.log(e.srcElement.value);
      brush.selectedTool = e.srcElement.value;
    }
  }
}

window.onload = function(){
  new Painter(document.getElementById('workfield'));
}
function project3D(x,y,z,vars){

	var p,d;
	x-=vars.camX;
	y-=vars.camY;
	z-=vars.camZ;
	p=Math.atan2(x,z);
	d=Math.sqrt(x*x+z*z);
	x=Math.sin(p-vars.yaw)*d;
	z=Math.cos(p-vars.yaw)*d;
	p=Math.atan2(y,z);
	d=Math.sqrt(y*y+z*z);
	y=Math.sin(p-vars.pitch)*d;
	z=Math.cos(p-vars.pitch)*d;
	p=Math.atan2(x,y);
	d=Math.sqrt(x*x+y*y);
	x=Math.sin(p-vars.roll)*d;
	y=Math.cos(p-vars.roll)*d;
	return {x:vars.cx+x/z*vars.scale,y:vars.cy+y/z*vars.scale,d:z>0?Math.sqrt(x*x+y*y+z*z):-1}
}

function rgb(col){

	col += 0.000001;
	var r = parseInt((0.5+Math.sin(col)*0.5)*16);
	var g = parseInt((0.5+Math.cos(col)*0.5)*16);
	var b = parseInt((0.5-Math.sin(col)*0.5)*16);
	return "#"+r.toString(16)+g.toString(16)+b.toString(16);
}

function process(vars){

	vars.scale-=Math.cos(vars.frameNo/40)*8;
	vars.shipSpeed+=Math.cos(vars.frameNo/40)/30;
	vars.yaw+=Math.cos(vars.frameNo/100)/80;
	vars.pitch+=Math.sin(vars.frameNo/70)/40;
	vars.roll-=Math.cos(vars.frameNo/130)/40;
	vars.shipVX=Math.sin(vars.yaw)*Math.cos(vars.pitch)*vars.shipSpeed;
	vars.shipVZ=Math.cos(vars.yaw)*Math.cos(vars.pitch)*vars.shipSpeed;
	vars.shipVY=Math.sin(vars.pitch)*vars.shipSpeed;
	vars.camX+=vars.shipVX;
	vars.camY+=vars.shipVY;
	vars.camZ+=vars.shipVZ;

	for(var i=0;i<vars.shapes.length;++i){
		rotateShape(vars.shapes[i],i/vars.shapes.length*.1,-i/vars.shapes.length*.1,i/vars.shapes.length*.1);
		if(vars.shapes[i].x-vars.camX>vars.fieldRadius)vars.shapes[i].x-=vars.fieldRadius*2;
		if(vars.shapes[i].x-vars.camX<-vars.fieldRadius)vars.shapes[i].x+=vars.fieldRadius*2;
		if(vars.shapes[i].y-vars.camY>vars.fieldRadius)vars.shapes[i].y-=vars.fieldRadius*2;
		if(vars.shapes[i].y-vars.camY<-vars.fieldRadius)vars.shapes[i].y+=vars.fieldRadius*2;
		if(vars.shapes[i].z-vars.camZ>vars.fieldRadius)vars.shapes[i].z-=vars.fieldRadius*2;
		if(vars.shapes[i].z-vars.camZ<-vars.fieldRadius)vars.shapes[i].z+=vars.fieldRadius*2;
	}
}

function sortFunction(a,b){
	return b.dist-a.dist;
}

function draw(vars){

	vars.ctx.globalAlpha=1;
	vars.ctx.fillStyle="rgba(0,0,0,.65)";
	vars.ctx.fillRect(0, 0, canvas.width, canvas.height);
	var x,y,z,point,pta,ptb,a;
	
	for(i=vars.shapes.length;i--;){
		x=vars.shapes[i].x;
		y=vars.shapes[i].y;
		z=vars.shapes[i].z;
		point=project3D(x,y,z,vars);
		a=1-Math.pow(point.d/vars.fieldRadius,10);
		vars.ctx.globalAlpha=a<0?0:a;
		vars.ctx.strokeStyle=rgb(vars.frameNo/16+(i/800)*(1/vars.scale*200));
		vars.ctx.lineWidth=40/(1+point.d);
		vars.ctx.beginPath();
		for(j=12;j--;){
			pta=project3D(x+vars.shapes[i].s[j].a.x,y+vars.shapes[i].s[j].a.y,z+vars.shapes[i].s[j].a.z,vars);
			ptb=project3D(x+vars.shapes[i].s[j].b.x,y+vars.shapes[i].s[j].b.y,z+vars.shapes[i].s[j].b.z,vars);
			if(pta.d!=-1&&ptb.d!=-1){
				vars.ctx.moveTo(pta.x,pta.y);
				vars.ctx.lineTo(ptb.x,ptb.y);
			}
		}
		vars.ctx.stroke();
	}
}

function rotateShape(shape, yaw, pitch, roll){
	var x,y,z,p,d;
	for(var i=0;i<shape.s.length;++i){
		for(var j=2;j--;){
			if(j){
				x=shape.s[i].a.x;
				y=shape.s[i].a.y;
				z=shape.s[i].a.z;
			}else{
				x=shape.s[i].b.x;
				y=shape.s[i].b.y;
				z=shape.s[i].b.z;
			}
			d=Math.sqrt(x*x+z*z);
			p=Math.atan2(x,z);
			x=Math.sin(p+yaw)*d;
			z=Math.cos(p+yaw)*d;
			d=Math.sqrt(y*y+z*z);
			p=Math.atan2(y,z);
			y=Math.sin(p+pitch)*d;
			z=Math.cos(p+pitch)*d;
			d=Math.sqrt(x*x+y*y);
			p=Math.atan2(x,y);
			x=Math.sin(p+roll)*d;
			y=Math.cos(p+roll)*d;
			if(j){
				shape.s[i].a.x=x;
				shape.s[i].a.y=y;
				shape.s[i].a.z=z;
			}else{
				shape.s[i].b.x=x;
				shape.s[i].b.y=y;
				shape.s[i].b.z=z;
			}
		}
	}
}

function S(x1,y1,z1,x2,y2,z2){
	this.a={x:x1,y:y1,z:z1};
	this.b={x:x2,y:y2,z:z2};
}

function Cube(x,y,z){

	Q={};
	Q.x=x;
	Q.y=y;
	Q.z=z;
	Q.s=[];
	Q.s.push(new S(-1,-1,-1,1,-1,-1));
	Q.s.push(new S(1,-1,-1,1,1,-1));
	Q.s.push(new S(1,1,-1,-1,1,-1));
	Q.s.push(new S(-1,1,-1,-1,-1,-1));
	Q.s.push(new S(-1,-1,1,1,-1,1));
	Q.s.push(new S(1,-1,1,1,1,1));
	Q.s.push(new S(1,1,1,-1,1,1));
	Q.s.push(new S(-1,1,1,-1,-1,1));
	Q.s.push(new S(-1,-1,-1,-1,-1,1));
	Q.s.push(new S(1,-1,-1,1,-1,1));
	Q.s.push(new S(1,1,-1,1,1,1));
	Q.s.push(new S(-1,1,-1,-1,1,1));
	return Q;
}

R=()=>Math.random()*Math.PI*2;

function loadScene(vars){
	
	vars.shapes=[];
	for(var i=0;i<vars.cubeNo;++i){
		var x=vars.fieldRadius-Math.random()*vars.fieldRadius*2;
		var y=vars.fieldRadius-Math.random()*vars.fieldRadius*2;
		var z=vars.fieldRadius-Math.random()*vars.fieldRadius*2;
		var c=new Cube(x,y,z);
		rotateShape(c,R(),R(),R());
		vars.shapes.push(c);
	}
}

function frame(vars) {

	if(vars === undefined){
		var vars={};
		vars.canvas = document.querySelector("canvas");
		vars.ctx = vars.canvas.getContext("2d");
		vars.canvas.width = document.body.clientWidth;
		vars.canvas.height = document.body.clientHeight;
		window.addEventListener("resize", function(){
			vars.canvas.width = document.body.clientWidth;
			vars.canvas.height = document.body.clientHeight;
			vars.cx=vars.canvas.width/2;
			vars.cy=vars.canvas.height/2;
		}, true);
		vars.frameNo=0;
		vars.canvas.addEventListener("mousemove",(e)=>{
			vars.mx=e.clientX/vars.canvas.clientWidth*vars.canvas.width
			vars.my=e.clientY/vars.canvas.clientHeight*vars.canvas.height
		});
		vars.camX = 0;
		vars.camY = 0;
		vars.camZ = 0;
		vars.pitch = 0;
		vars.yaw = 0;
		vars.roll = 0;
		vars.cx=vars.canvas.width/2;
		vars.cy=vars.canvas.height/2;
		vars.scale=400;

		vars.shipSpeed=1.5;
		vars.shipVX=vars.shipVY=vars.shipVZ=0;
		vars.fieldRadius=150;
		vars.cubeNo=1500;
		loadScene(vars);
	}

	vars.frameNo++;
	requestAnimationFrame(function() {
		frame(vars);
	});

	process(vars);
	draw(vars);
}
frame();
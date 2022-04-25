import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [`
      body {
          width: 100%;
          height: 100%;
          background-color: #f5f5f5;
          background-size: cover;
      }
      /*body:after{*/
      /*    content: "";*/
      /*    position: absolute;*/
      /*    top: 0;*/
      /*    left: 0;*/
      /*    width: 100vw;*/
      /*    height: 100%;*/
      /*    background: rgba(255,255,255, 0.5) no-repeat center center fixed;*/
      /*    background-size: cover;*/
      /*    z-index: 10;*/
      /*}*/
      .container-card{
          padding-top: 20px;
          position: relative;
          top: 0;
          left: 0;
          width: 100%;
          height: 100%;
          z-index: 100;
          background: rgba(255,255,255, 0.4) no-repeat center center fixed;
      }
  `],
})
export class AppComponent {
  title = 'app';
}

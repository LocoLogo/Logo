import { NgModule } from '@angular/core'; 
import { BrowserModule } from '@angular/platform-browser'; 
import { HttpModule } from '@angular/http'; 
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import 'rxjs/Rx'; 

// import our application component
import { AppComponent } from './app.component';
import { AppRouting } from './app.routing';
import { HomeComponent } from './components/home/home.component';

@NgModule({ 

        declarations: [ 

             AppComponent,
             HomeComponent

        ],    

        imports: [

             BrowserModule,   

             HttpModule,    
             FormsModule,
             ReactiveFormsModule,
             RouterModule,
             AppRouting
           

        ],     

        providers: [
          
        ],     

        bootstrap: [ 
    
            AppComponent     
        ], 
    }) 
    
    export class AppModule { 
        
    }
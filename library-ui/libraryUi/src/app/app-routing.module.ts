import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from '../app/components/home/home.component';
<<<<<<< HEAD
import { LoginComponent } from '../app/components/Login/login.component';
=======
>>>>>>> 8d2c53a45e2b9ab40b44fa4f110aedc989a5c1ec

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
<<<<<<< HEAD
  },
  {
    path: 'login',
    component: LoginComponent
  },
=======
},
>>>>>>> 8d2c53a45e2b9ab40b44fa4f110aedc989a5c1ec
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

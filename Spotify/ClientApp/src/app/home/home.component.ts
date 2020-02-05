import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    public songs: Songs[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Songs[]>(baseUrl + 'songs').subscribe(result => {
            this.songs = result;
        }, error => console.error(error));
    }
}
interface Songs {
    id: number;
    title: string;
    trackid: number;
    artists: number;
}

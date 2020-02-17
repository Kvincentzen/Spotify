import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-list',
    templateUrl: './list.component.html',
    styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
    public songs:Songs[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Songs[]>(baseUrl + 'song').subscribe(result => {
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

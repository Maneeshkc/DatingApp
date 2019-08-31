import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-Values',
  templateUrl: './Values.component.html',
  styleUrls: ['./Values.component.css']
})
export class ValuesComponent implements OnInit {
  value: any;
  constructor(private http: HttpClient) {
    http.get("http://localhost:5001/api/values").subscribe((res) => {
      this.value = res;
    }, (err) => {
      console.log(err);
    })

  }

  ngOnInit() {
  }

}

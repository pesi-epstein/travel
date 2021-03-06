import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Suggestion } from '../models/Suggestion';
import { SuggestionTraveler } from '../models/SuggestionTraveler';


@Injectable({
  providedIn: 'root'
})
export class SuggestionService {

  constructor(private http: HttpClient) { }
  post(suggestion: Suggestion) {
    return this.http.post(`${environment.apiUrl}/Suggestion`, suggestion);
  }
  put(suggestion: Suggestion) {
    return this.http.put(`${environment.apiUrl}/Suggestion`, suggestion);
  }
  get() {
    return this.http.get(`${environment.apiUrl}/Suggestion`);
  }
  delete(id: number) {
    return this.http.delete(`${environment.apiUrl}/Suggestion/${id}`, { params: { userId: JSON.parse(localStorage.getItem('currentUser')).UserID } });
  }
  getAll(id: number) {
    return this.http.get(`${environment.apiUrl}/Suggestions/${id}`);
  }

  // getAllTravel(id: number) {
  //   return this.http.get(`${environment.apiUrl}/SuggestionsAll/${id}`);
  // }

  getAllTravel() {
    return this.http.get(`${environment.apiUrl}/SuggestionsAll`);
  }

  getSuggestionsToTraveler(travelerId: number) {
    return this.http.get(`${environment.apiUrl}/SuggestionsWithStatus/${travelerId}`);
  }

  AddOrUpdateSuggestionStatus(suggestionTraveler: SuggestionTraveler) {
    return this.http.put(`${environment.apiUrl}/SaveStatus`, suggestionTraveler);
  }
}

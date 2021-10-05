import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Profile } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl } from '@core';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  uniqueIdentifierName: string = "profileId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public emailExists(email:string): Observable<{exists: boolean}> {
    return this._client.get<{exists: boolean}>(`${this._baseUrl}api/profile/email-exists/${email}`);
  }

  public get(): Observable<Profile[]> {
    return this._client.get<{ profiles: Profile[] }>(`${this._baseUrl}api/profile`)
      .pipe(
        map(x => x.profiles)
      );
  }

  public getById(options: { profileId: string }): Observable<Profile> {
    return this._client.get<{ profile: Profile }>(`${this._baseUrl}api/profile/${options.profileId}`)
      .pipe(
        map(x => x.profile)
      );
  }

  public remove(options: { profile: Profile }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/profile/${options.profile.profileId}`);
  }

  public create(options: { profile: Profile }): Observable<{ profile: Profile }> {
    return this._client.post<{ profile: Profile }>(`${this._baseUrl}api/profile`, { profile: options.profile });
  }

  public update(options: { profile: Profile }): Observable<{ profile: Profile }> {
    return this._client.put<{ profile: Profile }>(`${this._baseUrl}api/profile`, { profile: options.profile });
  }
}

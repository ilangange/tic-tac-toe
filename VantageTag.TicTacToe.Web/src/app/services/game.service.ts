import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { io } from "socket.io-client";
import { environment } from "src/environments/environment";
import * as signalR from '@microsoft/signalr';

@Injectable()
export class GameService {

	public gameGrid = <Array<Object>>[[1, 2, 3], [4, 5, 6], [7, 8, 9]];
	public socket: any;

	private headers = new HttpHeaders();

	constructor(private http: HttpClient) {
		this.headers.append('Accept', 'application/json');
		this.socket = new signalR.HubConnectionBuilder()
			.configureLogging(signalR.LogLevel.Information)
			.withUrl(environment.base_api + 'hub/game')
			.build();
	}

	// public getRoomStats() {
	// 	return new Promise(resolve => {
	// 		this.http.get(environment.base_api + 'v1/game/getroomstatus').subscribe((response: any) => {
	// 			resolve(response.data);
	// 		});
	// 	});
	// }

	connectSocket() {
		this.socket.start();
		//this.socket = io(environment.base_api + 'hub/game');
	}

	// getRoomsAvailable(): any {
	// 	const observable = new Observable(observer => {
	// 		this.socket.on('rooms-available', (data: any) => {
	// 			observer.next(
	// 				data
	// 			);
	// 		});
	// 		return () => {
	// 			this.socket.disconnect();
	// 		};
	// 	});
	// 	return observable;
	// }

	// createNewRoom(): any {
	// 	this.socket.emit('create-room', { 'TicTacToe-Room': 9909 });
	// 	const observable = new Observable(observer => {
	// 		this.socket.on('new-room', (data: any) => {
	// 			observer.next(
	// 				data
	// 			);
	// 		});
	// 		return () => {
	// 			this.socket.disconnect();
	// 		};
	// 	});
	// 	return observable;
	// }

	// joinNewRoom(roomNumber: any): any {
	// 	this.socket.emit('join-room', { 'roomNumber': roomNumber });
	// }

	joinRoom(): Observable<any> {
		return this.http.post(environment.base_api + 'api/v1/game/join-room/1',null);
	}

	startGame(): any {
		const observable = new Observable(observer => {
			this.socket.on('start-game', (data: any) => {
				observer.next(
					data
				);
			});
			return () => {
				this.socket.disconnect();
			};
		});
		return observable;
	}

	sendPlayerMove(params: any): any {
		this.http.post(environment.base_api + 'api/v1/game/move',params).subscribe((response: any) => {			
		});
	}

	receivePlayerMove(): any {
		const observable = new Observable(observer => {
			this.socket.on('receive-move', (data: any) => {
				observer.next(
					data
				);
			});
			return () => {
				this.socket.disconnect();
			};
		});
		return observable;
	}

	playerLeft(): any {
		const observable = new Observable(observer => {
			this.socket.on('room-disconnect', (data: any) => {
				observer.next(
					data
				);
			});
			return () => {
				this.socket.disconnect();
			};
		});
		return observable;
	}
}
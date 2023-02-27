import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { GameService } from 'src/app/services/game.service';

@Component({
	selector: 'app-game',
	templateUrl: './game.component.html',
	styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

	title = 'Welcome to Game Room';
	gameGrid: any = []; // = <Array<Object>>[];
	playedGameGrid: any = []; // = <Array<Object>>[];
	movesPlayed = <number>0;
	displayPlayerTurn = <Boolean>true;
	isOwnTurn = <Boolean>true;
	whoWillStart = <Boolean>true;

	@ViewChild('content') content: any;
	private modalOption: NgbModalOptions = {};

	roomNumber = 1;
	playedText = '';
	userTurn = 'X';

	constructor(private modalService: NgbModal,
		private gameService: GameService,) {
			this.gameGrid = gameService.gameGrid;
	}

	ngOnInit(): void {
	}
		
	ngAfterViewInit(): void {
		//console.log(this.content);
		this.modalOption.backdrop = 'static';
		this.modalOption.keyboard = false;
		this.modalOption.size = 'lg';
		const modalRef = this.modalService.open(this.content, this.modalOption);

		this.gameService.connectSocket();

		this.gameService.startGame().subscribe((response: any) => {
			modalRef.close();
		});

		this.gameService.receivePlayerMove().subscribe((response: any) => {
			this.opponentMove(response);
		});
	}

	renderPlayedText(number: any) {
		if (this.playedGameGrid === undefined || this.playedGameGrid[number] === undefined) {
			return '';
		}else {
			this.playedText = this.playedGameGrid[number]['player'];
			return this.playedText;
		}
	}

	play(number: any) {
		if (!this.userTurn) {
			return;
		}
		this.movesPlayed += 1;
		this.playedGameGrid[number] = {
			position: number,
			player: this.userTurn
		};

		let allPositions = this.playedGameGrid.filter((a: any) => a.player == this.userTurn).map((b: any) => b.position);
		this.gameService.sendPlayerMove({
			'roomId' : this.roomNumber,
			'playedSymbol': this.userTurn,
			'position' : number,
			'allPositions': allPositions,
			'movesPlayed' : this.movesPlayed
		});
		this.isOwnTurn = false;
		this.displayPlayerTurn = !this.displayPlayerTurn ? true : false;
	}

	joinRoom() {
		this.isOwnTurn = false;
		this.whoWillStart = false;
		this.gameService.joinRoom().subscribe((res: any) => {
			this.userTurn = res.data;
		});
	}

	opponentMove(params: any) {
		this.displayPlayerTurn = !this.displayPlayerTurn ? true : false;
		if (params['winner'] ===  null || params['winner'] ==  '') {
			this.playedGameGrid[params['position']] = {
				position: params['position'],
				player: params['playedSymbol']
			};
			this.isOwnTurn = true;
		}else {
			alert(params['winner']);
			this.resetGame();
		}
	}

	resetGame() {
		this.playedGameGrid = [];
		this.gameGrid = [];
		this.gameGrid = this.gameService.gameGrid;
		this.movesPlayed = 0;
		if (this.whoWillStart) {
			this.isOwnTurn = true;
			this.displayPlayerTurn = true;
			this.userTurn = 'X';
		}else {
			this.displayPlayerTurn = true;
			this.userTurn = 'O';
		}
	}

}

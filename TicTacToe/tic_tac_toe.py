# Tic-Tac-Toe (X/O): Build a two-player game where users take turns to place "X" or "O" on a 3x3 grid, using buttons or clickable areas.

import tkinter as tk
from tkinter import messagebox

class TicTacToe:
    def __init__(self):
        self.window = tk.Tk()
        self.window.title = "Tic-Tac-Toe"
        self.cur_player = "X"
        self.buttons = [[None]*3 for _ in range(3)]
        for i in range(3):
            for j in range(3):
                self.create_button(i, j)

    def create_button(self, row, col):
        button = tk.Button(
            self.window,
            text=" ",
            bd=5,
            font=("Helvetica", 20, "bold"),
            highlightbackground="#D8BFD8",
            fg="#A74B8D",
            width=8,
            height=4,
            command=lambda r=row, c=col: self.click_button(r, c)
        )
        button.grid(row=row, column=col)
        self.buttons[row][col] = button

    def click_button(self, row, col):
        if self.buttons[row][col]["text"] == " ":
            self.buttons[row][col]["text"] = self.cur_player

            if self.is_winner():
                self.winner_msg()
                self.reset()
            elif self.is_draw():
                self.draw_msg()
                self.reset()
            else:
                self.change_player()

    def is_winner(self):
        #check the rows and columns
        for i in range(3):
            if self.buttons[i][0]["text"] == self.buttons[i][1]["text"] == self.buttons[i][2]["text"] != " ":
                return True
            if self.buttons[0][i]["text"] == self.buttons[1][i]["text"] == self.buttons[2][i]["text"] != " ":
                return True
        #check diagonal
        return (
            self.buttons[0][0]["text"] == self.buttons[1][1]["text"] == self.buttons[2][2]["text"] != " " or
            self.buttons[0][2]["text"] == self.buttons[1][1]["text"] == self.buttons[2][0]["text"] != " "
        )
    def winner_msg(self):
        messagebox.showinfo("Tic tac toe", f"Player {self.cur_player} won the game!")

    def is_draw(self):
        return all(button["text"] != " " for row in self.buttons for button in row)
    def draw_msg(self):
        messagebox.showinfo("Tic tac toe", "Draw!")

    def change_player(self):
        self.cur_player = "O" if self.cur_player == "X" else "X"

    def reset(self):
        self.cur_player = "X"
        for row in self.buttons:
            for button in row:
                button["text"] = " "
    
    def run(self):
        self.window.mainloop()

if __name__ == "__main__":
    game = TicTacToe()
    game.run()
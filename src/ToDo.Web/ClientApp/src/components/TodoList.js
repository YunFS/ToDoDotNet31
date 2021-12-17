import React, { Component } from 'react';

export class TodoList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            todoList: []
        };
    }

    componentDidMount() {
        this.getTodoList();
    }

    getTodoList() {
        fetch('https://localhost:44396/api/ToDo')
            .then(response => response.json())
            .then(todo => this.setState({ todoList: todo }));
    }

    render() {
        return (
            <div>
                {this.state.todoList.map(todo => (
                    <div>
                        <h3 key={todo.id}>{todo.title}</h3>
                        <div>{todo.description}</div>
                        <br />
                    </div>))}
            </div>
        );
    }
}

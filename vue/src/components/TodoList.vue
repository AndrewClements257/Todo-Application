<template>
    <section class="todo-list">
        <div class="title">
            <h1>{{ currentListName }}</h1>
        </div>
        <div class="new-todo">
            <form  v-on:submit.prevent="createTodo()">
                <input type="text" placeholder="Todo Name" v-model="newTodo.name" required />
                <button>Add Todo</button>
            </form>
        </div>
        <div class="list">
            <ul>
                <li v-for="todo in todos" :key="todo.todo_id" v-bind:class="{ 'todo-completed': todo.isComplete }">
                    <input type="checkbox" v-model="todo.isComplete" v-on:change="checkTodoBox(todo)"/>
                    {{ todo.name }}
                    <span class="delete" @click="deleteTodo(todo.todo_ID)">×</span>
                </li>
            </ul>
        </div>
        <div class="completed">
            <h1>Completed {{ completedTodoCount }}</h1>
            <ul>
                <li v-for="todo in completed" :key="todo.todo_id" v-bind:class="{ 'todo-completed': todo.isComplete }">
                   <input type="checkbox" v-model="todo.isComplete" v-on:change="checkTodoBox(todo)"/>
                    {{ todo.name }}
                    <span class="delete" @click="deleteTodo(todo.todo_ID)">×</span>
                </li>
            </ul>
        </div>
    </section>
</template>

<script>
import TodoService from "../services/TodoService";

export default {
    name: "todo-list",
    created() {
        this.getCompleted(1);
    },
    data() {
        return {
        newTodo: {
            todo_id: 0,
            name: "",
            isComplete: false,
            list_id: 0
        }
        }
    },
    methods: {
        async getTodos(id) {
    try {
        const response = await TodoService.getTodos(id);
        this.$store.commit("SET_TODOS", response.data);
    } catch (error) {
        console.error("Error fetching todo lists:", error);
    }},
    async getCompleted(id) {
    try {
        const response = await TodoService.getCompleted(id);
        this.$store.commit("SET_COMPLETED", response.data);
    } catch (error) {
        console.error("Error fetching completed todos:", error);
    }},
    createTodo() {
  TodoService.newTodo(this.newTodo)
    .then(response => {
      if (response.status === 200) {
        this.getTodos(this.$store.state.currentList.list_ID)
        this.newTodo.name = "";
      }
    })
    .catch(error => {
      console.error('Error creating todo:', error);
    });
},
        deleteTodo(id) {
            TodoService
            .deleteTodo(id)
            .then(response => {
                if (response.status === 200) {
                    this.getTodos(this.$store.state.currentList.list_ID)
                }
            });
        },
        checkTodoBox(todo) {
    TodoService.markTodoDone(todo)
        .then(response => {
            if (response.status === 200) {
                // Remove the completed todo from the list
                const index = this.todos.findIndex(t => t.todo_id === todo.todo_id);
                if (index !== -1) {
                    this.todos.splice(index, 1);
                }
                this.getTodos(this.$store.state.currentList.list_ID);
                this.getCompleted(this.$store.state.currentList.list_ID);
            }
        })
        .catch(error => {
            console.error('Error marking todo as done:', error);
        });
},
    },
computed: {
    
        todos() {
            return this.$store.state.todos;
        },
        completed() {
            return this.$store.state.completed;
        },
        currentListName(){
            return this.$store.state.currentList.name;
        },
        completedTodoCount(){
            return this.$store.state.completed.length;
        }
        
    },
    watch: {
    '$store.state.currentList.list_ID': function(newListId) {
      this.newTodo.list_id = newListId;
    }
    }
}
</script>

<style scoped> 
    .todo-list {
        background-color: #fcfcfc;
        height: 100%;
        border-left: 1px solid #d1d1d1;
        margin-top: 40px;
    }

    .title {
        padding: 50px;
        padding-left: 25px;
        width: 100vw;
        color: white;
        text-shadow: 2px 2px 2px rgba(0,0,0,0.14);
        background: rgb(133,113,242);
        background: linear-gradient(156deg, rgba(133,113,242,1) 0%, rgba(0,167,255,1) 50%, rgba(133,113,242,1) 100%);
    }

    .title>h1 {
        font-size: 65px;
    }

    .list {
        padding-left: 50px;
        padding-bottom: 50px;
    }

    .delete {
    cursor: pointer;
    margin-top: 10px;
    display: block;
    float: right;
    }    

    .list>ul {
        font-size: 25px;
        font-weight: 400;
    }

    .completed {
        padding-left: 50px;
        padding-bottom: 50px;
    }

    .completed>ul {
        font-size: 25px;
        font-weight: 400;
    }

    .completed>h1 {
        font-size: 25px;
        font-weight: bold;
        padding-left: 0px;
    }
    
    input[type=checkbox] {
        margin-right: 25px;
        width: 18px;
        height: 18px;
        cursor: pointer;
    }

    .new-todo {
      padding-left: 50px;
      padding-top: 25px;
      padding-bottom: 25px;
  }

  .new-todo>form>button {
    padding: 4px 15px;
    background-color: rgb(250, 250, 250);
    color: #616161;
    border-style: none;
    font-weight: 500;
    border-radius: 0%;
  }

  .new-todo>form>button:hover {
    color: dodgerblue;
    background-color: rgb(248, 248, 248);
    cursor: pointer;
  }

li {
    background-color: white;
    border-radius: 5px;
    width: 80%;
    margin: 10px 0px;
    padding: 5px 15px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
}

li.todo-completed {
    text-decoration: line-through;
    color: darkgray;
}

.completed>h1 {
    color: #616161;
}
        
</style>
import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
});

export default {
    getTodos(id) {
        return http.get(`api/Todo/${id}`);
    },

    newTodo(todo) {
        return http.post(`api/Todo`,todo);
    },

    deleteTodo(id) {
        return http.delete(`api/Todo/${id}`);
      },

    markTodoDone(todo) {
        return http.put(`api/Todo`,todo);
<<<<<<< HEAD
<<<<<<< HEAD
    },
    getCompleted(id) {
        return http.get(`api/Todo/Completed/${id}`);
=======
>>>>>>> 56236b7102f8fc2eb871b6e9f5ce06d0a83abdaf
=======
>>>>>>> 48fa4ebe9f7bdb86c3afed4439c12c7f51eba555
    }
}
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
    },
    getCompleted(id) {
        return http.get(`api/Todo/Completed/${id}`);
    }
}
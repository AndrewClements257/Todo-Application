import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
});

export default {
    getLists(id) {
        return http.get(`api/List/${id}`);
    },

    getList(id) {
        return http.get(`api/List/Current/${id}`);
    },

    createList(newList) {
        return http.put(`api/List`,newList);
    },

    deleteList(id) {
        return http.delete(`api/List/${id}`);
    }
}
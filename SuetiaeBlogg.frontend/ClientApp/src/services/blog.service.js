import http from "../constants/http-common";

class BlogDataService {
    getAll() {
        return http.get("/AllPostsDetails");
    }
    get(id) {
        return http.get(`/${id}`);
    }
    getPostsByCategories(categoryId) {
        return http.get(`/categories/${categoryId}/posts`);
    }
    getPostsByTags(tagId) {
        return http.get(`/tag/${tagId}/posts`);
    }
    getPostsByAuthors(authorId) {
        return http.get(`/authors/${authorId}/posts`);
    }
    getCategories() {
        return http.get("/categories");
    }

    create(data) {
        return http.post("/InsertNewPost", data)
            .then((res) => (res.data))
            .catch((err) => console.log(err))
            ;
    }
    //update(id, data) {
    //    return http.put(, data);
    //}

    //delete(id) {
    //    return http.delete(${id}`);
    //}

    //deleteAll() {
    //    return http.delete(`);
    //}

    //findByTitle(title) {
    //    return http.get(`/}`);
    //}
}

export default new BlogDataService();
import { useState } from "react";
import TweetsList from "../TweetsList";
import axios from "axios";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweetResponse, setTweetResponse] = useState();
  const [searchChoice, setSearchChoice] = useState("Username");

  async function getTweets(e) {
    e.preventDefault();
    let res;

    if (searchChoice === "Username") {
      res = await axios.get(
        `api/tweets/search/username?searchTerm=${searchTerm}`
      );
    } else {
      res = await axios.get(
        `api/tweets/search/content?searchTerm=${searchTerm}`
      );
    }
    setTweetResponse(res.data);
  }

  return (
    <div>
      <h1 className="title">Search Tweets</h1>
      <form>
        <div className="form-row">
          <div className="col-auto">
            <input
              className="form-control"
              type="text"
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </div>
          <div className="col-auto">
            <button
              className="btn btn-primary form-control"
              type="submit"
              onClick={(e) => getTweets(e)}
              disabled={!searchTerm}
            >
              Search
            </button>
          </div>
          <div className="btn-group" role="group">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={(e) => setSearchChoice(e.target.textContent)}
            >
              Username
            </button>
            <button
              type="button"
              className="btn btn-secondary"
              onClick={(e) => setSearchChoice(e.target.textContent)}
            >
              Content
            </button>
          </div>
        </div>
      </form>
      <div>
        <TweetsList tweetResponse={tweetResponse} />
      </div>
    </div>
  );
};

export default Search;

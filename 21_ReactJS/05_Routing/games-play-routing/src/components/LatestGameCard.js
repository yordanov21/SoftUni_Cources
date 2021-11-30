import { Link } from 'react-router-dom';

const LatestGameCard = ({
    game,
}) => {
    return (
        <div className="game">
            <div className="image-wrap">
                <img src={game.imageUrl} />
            </div>
            <h3>{game.title}</h3>
            <div className="rating">
                <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
            </div>
            <div class="data-buttons">
                <Link
                    to={`/games/${game._id}`}
                    class="btn details-btn"
                >
                    Details
                </Link>
            </div>
        </div>
    );
};

export default LatestGameCard;
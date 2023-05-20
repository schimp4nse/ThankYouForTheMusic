using Models.Responses;

namespace Interfaces;

public interface IPlayistService {

    PlaylistResponse AddPlaylistAsync(string playlistName);
}
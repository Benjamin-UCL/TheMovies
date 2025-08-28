using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.Data;
using TheMovies.Model;
using TheMovies.Utility;

namespace TheMovies.ViewModel;

public class Screening_ViewModel : ViewModelBase
{
    // Repositories
    public CsvScreeningRepository ScreeningRepository = new CsvScreeningRepository("Screenings.csv");

    // Collections
    public ObservableCollection<Screening> Screenings { get; } = new ObservableCollection<Screening>();

    // Variables


    // Constructor
    public Screening_ViewModel()
    {
        this.addScreeningCommand = new RelayCommand(addScreening, canAddScreening);

        ScreeningRepository.GetAll().ForEach(s => Screenings.Add(s));
    }


    // Commands
    public ICommand addScreeningCommand { get; }

    public void addScreening()
    {
        //this.Screenings.Add(new Screening());
    }

    public bool canAddScreening()
    {
        return true;
    }

}
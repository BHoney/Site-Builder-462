library(shiny)

# Define UI for application that draws a histogram
shinyUI(fluidPage(
  
  # Application title
  titlePanel("Hello Cool Cats"),
  
  # Sidebar with a slider input for the number of bins
  sidebarLayout(position = c("right"),
    sidebarPanel(
      dateRangeInput("dateRange", "Date Range"),
      br(),
      br(),
      numericInput("numInput", "Enter a value", 0),
      br(),
      br(),
      sliderInput("bins",
                  "Number of bins:",
                  min = 1,
                  max = 5,
                  value = 30)
    ),
    
    # Show a plot of the generated distribution
    mainPanel(
      includeHTML("canvasPractice.html")
      #plotOutput("distPlot")
    )
  )
))